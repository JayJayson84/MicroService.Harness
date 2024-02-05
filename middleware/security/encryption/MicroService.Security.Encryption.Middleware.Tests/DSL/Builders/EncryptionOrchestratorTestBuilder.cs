using AutoMapper;
using MicroService.Security.Encryption.Contracts;
using MicroService.Security.Encryption.Interfaces;
using MicroService.Security.Encryption.Middleware.DTOs;
using MicroService.Security.Encryption.Middleware.Orchestrators.Interfaces;
using MicroService.Security.Encryption.Middleware.Tests.DSL.Subjects;
using MicroService.Security.Encryption.Models;
using Microsoft.Extensions.Logging;
using Moq;

namespace MicroService.Security.Encryption.Middleware.Tests.DSL.Builders;

public class EncryptionOrchestratorTestBuilder<TOrchestrator> where TOrchestrator : IEncryptionOrchestrator
{
    private readonly ILogger<TOrchestrator> _logger;
    private readonly Mock<IEncryptionServiceFactory> _mockEncryptionServiceFactory;
    private readonly Mock<IEncryptionService> _mockEncryptionService;
    private readonly Mock<IMapper> _mockMapper;
    private string? _encryptedString;
    private string? _decryptedString;

    public EncryptionOrchestratorTestBuilder()
    {
        _logger = Mock.Of<ILogger<TOrchestrator>>();
        _mockEncryptionServiceFactory = new();
        _mockEncryptionService = new();
        _mockMapper = new();
    }

    public EncryptionOrchestratorTestBuilder<TOrchestrator> WithEncryptedString(string? encryptedString)
    {
        _encryptedString = encryptedString;

        return this;
    }

    public EncryptionOrchestratorTestBuilder<TOrchestrator> WithDecryptedString(string? decryptedString)
    {
        _decryptedString = decryptedString;

        return this;
    }

    public EncryptionOrchestratorSut Build()
    {
        _mockEncryptionService
            .Setup(x => x.EncryptString(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string?>()))
            .Returns(_encryptedString);
        
        _mockEncryptionService
            .Setup(x => x.DecryptString(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string?>()))
            .Returns(_decryptedString);

        _mockEncryptionServiceFactory
            .Setup(x => x.GetService(It.IsAny<Enums.EncryptionMethod>(), It.IsAny<SymmetricAlgorithmOptions>()))
            .Returns(_mockEncryptionService.Object);

        _mockMapper.Setup(x => x.Map<EncryptionDto>(It.IsAny<EncryptionContract>())).Returns(new EncryptionDto());

        var orchestrator = (TOrchestrator)Activator.CreateInstance(typeof(TOrchestrator),
            _logger,
            _mockEncryptionServiceFactory.Object,
            _mockMapper.Object)!;
        
        return new EncryptionOrchestratorSut()
        {
            EncryptionOrchestrator = orchestrator
        };
    }

    public static EncryptionOrchestratorTestBuilder<TOrchestrator> ConfigureTests() => new();
}
