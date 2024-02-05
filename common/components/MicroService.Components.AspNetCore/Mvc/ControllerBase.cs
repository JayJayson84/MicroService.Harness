using System.Net.Mime;
using System.Reflection;
using System.Text.RegularExpressions;
using MassTransit;
using MassTransit.Metadata;
using MicroService.Components.AspNetCore.Enums;
using MicroService.Logging.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MicroService.Components.AspNetCore.Mvc;

/// <summary>
/// A base class to extend MVC controllers without view support.
/// </summary>
public abstract class ControllerBase(ILogger logger, IConfiguration configuration) : Microsoft.AspNetCore.Mvc.ControllerBase
{
    readonly ILogger _logger = logger;
    IConfiguration _configuration = configuration;

    const string FALLBACK_RESPONSE = "No content was generated from the request.";

#pragma warning disable IDE1006 // Naming Styles
    private Lazy<ObjectResult> _fallbackResponse => new(StatusCode(StatusCodes.Status500InternalServerError, new
    {
        ResponseCode = StatusCodes.Status204NoContent,
        ResponseType = MediaTypeNames.Text.Plain,
        Response = FALLBACK_RESPONSE
    }));
#pragma warning restore IDE1006 // Naming Styles

    /// <summary>
    /// A default <see cref="ObjectResult"/> response for unhandled requests.
    /// </summary>
    public ObjectResult FallbackResponse => _fallbackResponse.Value;

    /// <summary>
    /// An endpoint to check if the API is healthy.
    /// </summary>
    /// <returns>An IActionResult object with the response message, type and status code.</returns>
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> CheckEndpoint()
    {
        var taskCompletionSource = new TaskCompletionSource<IActionResult>();

        ObjectResult? result = null;

        try
        {
            _logger.LogInformationWithContext("Checking healthy status of endpoint.");

            result = StatusCode(StatusCodes.Status200OK, new
            {
                ResponseCode = StatusCodes.Status200OK,
                ResponseType = MediaTypeNames.Text.Plain,
                Response = "Endpoint is healthy."
            });
        }
        catch (Exception ex)
        {
            _logger.LogErrorWithContext("Exception handled in user code.");

            result = StatusCode(StatusCodes.Status500InternalServerError, new
            {
                ResponseCode = StatusCodes.Status500InternalServerError,
                ResponseType = MediaTypeNames.Text.Plain,
                Response = ex.Message
            });
        }
        finally
        {
            taskCompletionSource.SetResult(result ?? FallbackResponse);
        }

        return taskCompletionSource.Task;
    }

    /// <summary>
    /// Gets a message envelope representing the payload for the consumer.
    /// </summary>
    /// <param name="envelopeType">Specify the verbosity of the generated envelope.</param>
    /// <param name="contract">A contract that will be processed by a consumer.</param>
    /// <param name="rootAssemblyName">The root AssemblyName of the project.</param>
    /// <param name="callerType">A type whose name can be used to infer the queue name of a consumer.</param>
    /// <returns>An IActionResult object with the response message, type and status code.</returns>
    public IActionResult GetEnvelope<TContract, TResponse>(EnvelopeType envelopeType, object? contract, AssemblyName rootAssemblyName, Type callerType) where TContract : class where TResponse : class
    {
        var contractType = typeof(TContract);
        var responseType = typeof(TResponse);
        var messageType = new List<string>() { $"urn:message:{contractType.Namespace}:{contractType.Name}" };
        contractType
            .GetInterfaces()
            .Where(i => !i.Namespace!.StartsWith("System", StringComparison.InvariantCultureIgnoreCase))
            .ToList()
            .ForEach(i => messageType.Add($"urn:message:{i.Namespace}:{i.Name}"));
        var hostInfo = HostMetadataCache.Host;
        var uId = string.Concat(Guid.NewGuid().ToString().Except(['-']).Take(26));
        var bus = $"{hostInfo.MachineName}_{rootAssemblyName.Name!.Replace(".", string.Empty)}_bus_{uId}";
        var hostname = _configuration["RabbitMQ:Hostname"];
        var virtualHost = _configuration["RabbitMQ:VirtualHost"];
        var queueName = Regex.Replace(callerType.Name, "controller|consumer", string.Empty, RegexOptions.IgnoreCase);
        var sourceAddress = $"rabbitmq://{hostname}/{virtualHost}/{bus}?temporary=true";
        var destinationAddress = $"rabbitmq://{hostname}/{virtualHost}/{queueName}";
        var responseAddress = $"rabbitmq://{hostname}/{virtualHost}/{bus}?temporary=true";

        dynamic envelope = envelopeType switch
        {
            EnvelopeType.Verbose => new
            {
                messageId = NewId.NextGuid(),
                requestId = NewId.NextGuid(),
                correlationId = (string?)null,
                conversationId = NewId.NextGuid(),
                initiatorId = (string?)null,
                sourceAddress,
                destinationAddress,
                responseAddress,
                faultAddress = (string?)null,
                messageType,
                message = contract,
                expirationTime = DateTime.UtcNow.AddSeconds(30),
                sentTime = DateTime.UtcNow,
                headers = new Dictionary<string, object?>()
                {
                    {
                        "MT-Request-AcceptType", new object[]
                        {
                            $"urn:message:{responseType.Namespace}:{responseType.Name}"
                        }
                    }
                },
                host = new
                {
                    machineName = hostInfo.MachineName,
                    processName = hostInfo.ProcessName,
                    processId = hostInfo.ProcessId,
                    assembly = hostInfo.Assembly,
                    assemblyVersion = hostInfo.AssemblyVersion,
                    frameworkVersion = hostInfo.FrameworkVersion,
                    massTransitVersion = hostInfo.MassTransitVersion,
                    operatingSystemVersion = hostInfo.OperatingSystemVersion
                }
            },
            _
            => new
            {
                MessageType = messageType,
                Message = contract
            }
        };

        _logger.LogInformationWithContext($"Message envelope created for type {contractType}.");

        return StatusCode(StatusCodes.Status200OK, envelope);
    }
}
