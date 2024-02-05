using System.Collections;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using MassTransit;
using MicroService.Logging.Extensions;
using MicroService.Security.Encryption.Contracts;
using MicroService.Security.Encryption.Middleware.Orchestrators.Interfaces;

namespace MicroService.Security.Consumers;

public sealed class EncryptionConsumer(
    ILogger<EncryptionConsumer> logger,
    IEncryptionOrchestrator encryptionOrchestrator
) : IConsumer<EncryptionContract>
{
    readonly ILogger<EncryptionConsumer> _logger = logger;
    readonly IEncryptionOrchestrator _encryptionOrchestrator = encryptionOrchestrator;

    public async Task Consume(ConsumeContext<EncryptionContract> context)
    {
        try
        {
            if (!context.TryGetMessage<EncryptionContract>(out var contract))
            {
                throw new PayloadException($"Message type {nameof(EncryptionContract)} could not be consumed from the context.");
            }

            _logger.LogInformationWithContext("Encryption request receieved.");

            var response = await _encryptionOrchestrator.ExecuteCryptoOperationAsync(contract.Message, context.CancellationToken);

            _logger.LogInformationWithContext("Encryption request completed.");

            await context.RespondAsync<EncryptionResponse>(new
            {
                ResponseCode = (int)HttpStatusCode.OK,
                ResponseType = MediaTypeNames.Text.Plain,
                response?.Message
            });
        }
        catch (AggregateException ae)
        {
            var exceptionMessages = ae
                .Flatten()
                .InnerExceptions
                .Select(x => x.Message);
            var exceptionMessagesJson = JsonSerializer.Serialize(exceptionMessages);

            await context.RespondAsync<EncryptionResponse>(new
            {
                ResponseCode = (int)HttpStatusCode.InternalServerError,
                ResponseType = MediaTypeNames.Application.Json,
                Message = exceptionMessagesJson
            });

            throw;
        }
        catch (TaskCanceledException ex)
        {
            string message;
            string responseType;

            IDictionary? data = ex?.Data?.Count > 0
                ? ex.Data
                : ex?.InnerException?.Data?.Count > 0
                    ? ex.InnerException.Data
                    : null;

            if (data == null)
            {
                responseType = MediaTypeNames.Text.Plain;
                message = ex?.Message ?? "A task was cancelled without additional data.";
            }
            else
            {
                responseType = MediaTypeNames.Application.Json;
                message = JsonSerializer.Serialize(data
                    .OfType<DictionaryEntry>()
                    .ToDictionary(entry => (string)entry.Key, entry => entry.Value)
                    .Select(kvp => $"{kvp.Key}: {kvp.Value}"));
            }

            await context.RespondAsync<EncryptionResponse>(new
            {
                ResponseCode = (int)HttpStatusCode.InternalServerError,
                ResponseType = responseType,
                Message = message
            });

            throw new InvalidOperationException(message);
        }
        catch (Exception ex)
        {
            await context.RespondAsync<EncryptionResponse>(new
            {
                ResponseCode = (int)HttpStatusCode.InternalServerError,
                ResponseType = MediaTypeNames.Text.Plain,
                ex.Message
            });

            throw;
        }
    }
}
