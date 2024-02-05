using System.ComponentModel;
using AutoMapper;
using MicroService.Logging.Extensions;
using MicroService.Security.Encryption.Contracts;
using MicroService.Security.Encryption.Interfaces;
using MicroService.Security.Encryption.Middleware.DTOs;
using MicroService.Security.Encryption.Middleware.Orchestrators.Interfaces;
using Microsoft.Extensions.Logging;

namespace MicroService.Security.Encryption.Middleware.Orchestrators.Implementation;

internal class EncryptionOrchestrator(
    ILogger<EncryptionOrchestrator> logger,
    IEncryptionServiceFactory encryptionServiceFactory,
    IMapper mapper
) : IEncryptionOrchestrator
{
    readonly ILogger<EncryptionOrchestrator> _logger = logger;
    readonly IEncryptionServiceFactory _encryptionServiceFactory = encryptionServiceFactory;
    readonly IMapper _mapper = mapper;

    #region Public Methods

    public Task<EncryptionResponse> ExecuteCryptoOperationAsync(EncryptionContract contract, CancellationToken cancellationToken = default)
    {
        if (contract == null) throw new ArgumentException(null, nameof(contract));

        return contract.EncryptionOperation switch
        {
            EncryptionOperation.Encrypt => EncryptStringAsyncInternal(contract, cancellationToken),
            EncryptionOperation.Decrypt => DecryptStringAsyncInternal(contract, cancellationToken),
            _
            => throw new InvalidEnumArgumentException(nameof(contract.EncryptionOperation), (int?)contract.EncryptionOperation ?? -1, typeof(EncryptionOperation))
        };
    }

    public Task<EncryptionResponse> EncryptStringAsync(EncryptionContract contract, CancellationToken cancellationToken = default)
    {
        if (contract == null) throw new ArgumentException(null, nameof(contract));

        return EncryptStringAsyncInternal(contract, cancellationToken);
    }

    public Task<EncryptionResponse> DecryptStringAsync(EncryptionContract contract, CancellationToken cancellationToken = default)
    {
        if (contract == null) throw new ArgumentException(null, nameof(contract));

        return DecryptStringAsyncInternal(contract, cancellationToken);
    }

    #endregion

    #region Private Methods

    private async Task<EncryptionResponse> EncryptStringAsyncInternal(EncryptionContract contract, CancellationToken cancellationToken)
    {
        try
        {
            return await Task.Run(() =>
            {
                _logger.LogInformationWithContext("Encryption task started.");

                var encryptionDto = _mapper.Map<EncryptionDto>(contract);

                ArgumentNullException.ThrowIfNull(encryptionDto);
                cancellationToken.ThrowIfCancellationRequested();

                var encryptionService = _encryptionServiceFactory.GetService(encryptionDto.EncryptionMethod, encryptionDto.EncryptionOptions);

                ArgumentNullException.ThrowIfNull(encryptionService);
                cancellationToken.ThrowIfCancellationRequested();

                return encryptionService.EncryptString(encryptionDto.Value, encryptionDto.Key, encryptionDto.Salt);
            },
            cancellationToken).ContinueWith((antecedent) =>
            {
                _logger.LogInformationWithContext("Encryption task completed.");

                var value = antecedent.Result;

                return new EncryptionResponse
                {
                    Message = value
                };
            },
            cancellationToken,
            TaskContinuationOptions.OnlyOnRanToCompletion,
            TaskScheduler.Current);
        }
        catch (TaskCanceledException ex)
        {
            _logger.LogErrorWithContext(ex, "Encryption task failed.");
            throw new TaskCanceledException("The string could not be encrypted.", ex);
        }
    }

    private async Task<EncryptionResponse> DecryptStringAsyncInternal(EncryptionContract contract, CancellationToken cancellationToken)
    {
        try
        {
            return await Task.Run(() =>
            {
                _logger.LogInformationWithContext("Decryption task started.");

                var encryptionDto = _mapper.Map<EncryptionDto>(contract);

                ArgumentNullException.ThrowIfNull(encryptionDto);
                cancellationToken.ThrowIfCancellationRequested();

                var encryptionService = _encryptionServiceFactory.GetService(encryptionDto.EncryptionMethod, encryptionDto.EncryptionOptions);

                ArgumentNullException.ThrowIfNull(encryptionService);
                cancellationToken.ThrowIfCancellationRequested();

                return encryptionService.DecryptString(encryptionDto.Value, encryptionDto.Key, encryptionDto.Salt);
            },
            cancellationToken).ContinueWith((antecedent) =>
            {
                _logger.LogInformationWithContext("Decryption task completed.");

                var value = antecedent.Result;

                return new EncryptionResponse
                {
                    Message = value
                };
            },
            cancellationToken,
            TaskContinuationOptions.OnlyOnRanToCompletion,
            TaskScheduler.Current);
        }
        catch (TaskCanceledException ex)
        {
            _logger.LogErrorWithContext(ex, "Decryption task failed.");
            throw new TaskCanceledException("The string could not be decrypted.", ex);
        }
    }

    #endregion

}
