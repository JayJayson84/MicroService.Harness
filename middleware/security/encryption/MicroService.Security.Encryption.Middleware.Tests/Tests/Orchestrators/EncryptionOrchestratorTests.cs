using System.ComponentModel;
using MicroService.Components.Tests.Fakes.Builders;
using MicroService.Security.Encryption.Contracts;
using MicroService.Security.Encryption.Middleware.Orchestrators.Implementation;
using MicroService.Security.Encryption.Middleware.Tests.DSL.Builders;

namespace MicroService.Security.Encryption.Middleware.Tests.Tests.Orchestrators;

public class EncryptionOrchestratorTests
{

    [Fact]
    public async void GivenExecuteCryptoOperationAsyncIsInvoked_WhenEncryptionOperationEqualsEncrypt_ThenReturnEncryptionResponseWithEncryptedString()
    {
        // Arrange
        var contract = FakeEncryptionContractBuilder
            .CreateBuilder(addMockData: true)
            .WithEncryptionOperation(EncryptionOperation.Encrypt)
            .Build();
        var sut = EncryptionOrchestratorTestBuilder<EncryptionOrchestrator>
            .ConfigureTests()
            .WithEncryptedString("EncryptedString")
            .Build()
            .EncryptionOrchestrator;
        
        // Act
        var result = await sut.ExecuteCryptoOperationAsync(contract);

        // Assert
        Assert.IsType<EncryptionResponse?>(result);
        Assert.Equal(result.Message, "EncryptedString");
    }

    [Fact]
    public async void GivenExecuteCryptoOperationAsyncIsInvoked_WhenEncryptionOperationEqualsDecrypt_ThenReturnEncryptionResponseWithDecryptedString()
    {
        // Arrange
        var contract = FakeEncryptionContractBuilder
            .CreateBuilder(addMockData: true)
            .WithEncryptionOperation(EncryptionOperation.Decrypt)
            .Build();
        var sut = EncryptionOrchestratorTestBuilder<EncryptionOrchestrator>
            .ConfigureTests()
            .WithDecryptedString("DecryptedString")
            .Build()
            .EncryptionOrchestrator;
        
        // Act
        var result = await sut.DecryptStringAsync(contract);

        // Assert
        Assert.IsType<EncryptionResponse?>(result);
        Assert.Equal(result.Message, "DecryptedString");
    }

    [Fact]
    public async void GivenExecuteCryptoOperationAsyncIsInvoked_WhenEncryptionOperationIsNotValid_ThenThrowAnInvalidEnumArgumentException()
    {
        // Arrange
        var contract = FakeEncryptionContractBuilder
            .CreateBuilder()
            .WithEncryptionOperation((EncryptionOperation)(-1))
            .Build();
        var sut = EncryptionOrchestratorTestBuilder<EncryptionOrchestrator>
            .ConfigureTests()
            .Build()
            .EncryptionOrchestrator;

        // Act
        Task<EncryptionResponse> ExecuteCryptoOperationAsync() => sut.ExecuteCryptoOperationAsync(contract);

        // Assert
        await Assert.ThrowsAsync<InvalidEnumArgumentException>(ExecuteCryptoOperationAsync);
    }

    [Fact]
    public async void GivenEncryptStringAsyncIsInvoked_WhenEncryptionContractIsValid_ThenReturnEncryptionResponseWithEncryptedString()
    {
        // Arrange
        var contract = FakeEncryptionContractBuilder
            .CreateBuilder(addMockData: true)
            .Build();
        var sut = EncryptionOrchestratorTestBuilder<EncryptionOrchestrator>
            .ConfigureTests()
            .WithEncryptedString("EncryptedString")
            .Build()
            .EncryptionOrchestrator;
        
        // Act
        var result = await sut.EncryptStringAsync(contract);

        // Assert
        Assert.IsType<EncryptionResponse?>(result);
        Assert.Equal(result.Message, "EncryptedString");
    }

    [Fact]
    public async void GivenDecryptStringAsyncIsInvoked_WhenEncryptionContractIsValid_ThenReturnEncryptionResponseWithDecryptedString()
    {
        // Arrange
        var contract = FakeEncryptionContractBuilder
            .CreateBuilder(addMockData: true)
            .Build();
        var sut = EncryptionOrchestratorTestBuilder<EncryptionOrchestrator>
            .ConfigureTests()
            .WithDecryptedString("DecryptedString")
            .Build()
            .EncryptionOrchestrator;
        
        // Act
        var result = await sut.DecryptStringAsync(contract);

        // Assert
        Assert.IsType<EncryptionResponse?>(result);
        Assert.Equal(result.Message, "DecryptedString");
    }

}
