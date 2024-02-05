using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using MassTransit;
using MicroService.Components.AspNetCore.Enums;
using MicroService.Logging.Extensions;
using MicroService.Security.Encryption.Contracts;
using MicroService.Security.Encryption.Extensions;
using Microsoft.AspNetCore.Mvc;
using ControllerBase = MicroService.Components.AspNetCore.Mvc.ControllerBase;

namespace MicroService.Security.Producers.Controllers;

/// <summary>
/// Produces encryption requests.
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
public sealed class EncryptionController(
    ILogger<EncryptionController> logger,
    IConfiguration configuration,
    IRequestClient<EncryptionContract> requestClient) : ControllerBase(logger, configuration)
{
    readonly ILogger<EncryptionController> _logger = logger;
    readonly IRequestClient<EncryptionContract> _requestClient = requestClient;

    /// <summary>
    /// Publishes a <see cref="EncryptionContract"/> to a consumer to encrypt or decrypt a string and subscribe to the response.
    /// </summary>
    /// <param name="model">A contract that represents the payload that will be processed by the consumer.</param>
    /// <remarks>The Key and Salt values are not encoded.</remarks>
    /// <returns>An IActionResult object with the response message, type and status code.</returns>
    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CryptoOperation([Required][FromBody] EncryptionContract model)
    {
        ObjectResult? result;

        try
        {
            _logger.LogInformationWithContext("Crypto operation started.");

            ArgumentNullException.ThrowIfNull(model);

            var response = await _requestClient.GetResponse<EncryptionResponse>(model);
            var responseMessage = response.Message;

            _logger.LogInformationWithContext("Crypto operation completed.");

            result = StatusCode(StatusCodes.Status200OK, new
            {
                responseMessage.ResponseCode,
                responseMessage.ResponseType,
                Response = responseMessage.Message
            });
        }
        catch (Exception ex)
        {
            _logger.LogErrorWithContext(ex, "Exception handled in user code.");

            result = StatusCode(StatusCodes.Status500InternalServerError, new
            {
                ResponseCode = StatusCodes.Status500InternalServerError,
                ResponseType = MediaTypeNames.Text.Plain,
                Response = ex.Message
            });
        }

        return result ?? FallbackResponse;
    }

    /// <summary>
    /// Publishes a <see cref="EncryptionContract"/> to a consumer to encrypt a string and subscribe to the response.
    /// </summary>
    /// <param name="value">The UTF-16 string to encrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <param name="salt">The salt value to use for the symmetric algorithm. If omitted, a unique salt is generated and appended to the output.</param>
    /// <remarks>Encodes the <paramref name="key"/> and <paramref name="salt"/> to SHA256 hash strings.</remarks>
    /// <returns>An IActionResult object with the response message, type and status code.</returns>
    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> EncryptString(
        [Required] EncryptionMethod encryptionMethod,
        [Required] string value,
        [Required] string key,
        string? salt = null)
    {
        var model = new EncryptionContract()
        {
            Value = value,
            Key = key.ToSHA256Hash(Encoding.UTF8)!,
            Salt = salt?.ToSHA256Hash(Encoding.UTF8),
            EncryptionOperation = EncryptionOperation.Encrypt,
            EncryptionMethod = encryptionMethod
        };

        _logger.LogInformationWithContext("Key encoded to SHA256 hash string.");

        return await CryptoOperation(model);
    }

    /// <summary>
    /// Publishes a <see cref="EncryptionContract"/> to a consumer to decrypt a string and subscribe to the response.
    /// </summary>
    /// <param name="value">The UTF-16 string to encrypt.</param>
    /// <param name="key">The secret key to use for the symmetric algorithm.</param>
    /// <param name="encryptionMethod">The type of symmetric algorithm to use.</param>
    /// <param name="salt">The salt value to use for the symmetric algorithm. If omitted, a unique salt is generated and appended to the output.</param>
    /// <remarks>Encodes the <paramref name="key"/> and <paramref name="salt"/> to SHA256 hash strings.</remarks>
    /// <returns>An IActionResult object with the response message, type and status code.</returns>
    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DecryptString(
        [Required] EncryptionMethod encryptionMethod,
        [Required] string value,
        [Required] string key,
        string? salt = null)
    {
        var model = new EncryptionContract()
        {
            Value = value,
            Key = key.ToSHA256Hash(Encoding.UTF8)!,
            Salt = salt?.ToSHA256Hash(Encoding.UTF8),
            EncryptionOperation = EncryptionOperation.Decrypt,
            EncryptionMethod = encryptionMethod
        };

        _logger.LogInformationWithContext("Key encoded to SHA256 hash string.");

        return await CryptoOperation(model);
    }

    /// <inheritdoc cref="ControllerBase.GetEnvelope{TContract, TResponse}(EnvelopeType, object?, AssemblyName, Type)"/>
    /// <param name="envelopeType">Specify the verbosity of the generated envelope.</param>
    /// <param name="contract">A contract that will be processed by a consumer.</param>
    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult CryptoOperationEnvelope([Required][FromBody] EncryptionContract contract, [FromQuery]EnvelopeType envelopeType = EnvelopeType.Minimal)
    {
        return GetEnvelope<EncryptionContract, EncryptionResponse>(envelopeType, contract, AssemblyInfo.GetName(), typeof(EncryptionController));
    }
}