using MicroService.Components.Tests.DSL.Builders;
using MicroService.Components.Tests.Fakes;
using MicroService.Security.Encryption.Enums;
using MicroService.Security.Encryption.Middleware.DTOs;
using MicroService.Security.Encryption.Middleware.Mappers;

namespace MicroService.Security.Encryption.Middleware.Tests.Tests.Mappers;

public class EncryptionMapperProfileTests
{
    [Fact]
    public void EncryptionMapperProfile_Configuration_IsValid()
    {
        // Arrange
        var sut = MapperTestBuilder<EncryptionMapperProfile>
            .ConfigureTests()
            .Build()
            .MapperConfiguration;
        
        // Assert
        sut.AssertConfigurationIsValid();
    }

    [Fact]
    public void EncryptionMapperProfile_EncryptionContract_MapsToEncryptionDto()
    {
        // Arrange
        var contract = FakeContractFactory
            .CreateEncryptionContract(addMockData: true)
            .Build();
        var sut = MapperTestBuilder<EncryptionMapperProfile>
            .ConfigureTests()
            .Build()
            .Mapper;

        // Act
        var result = sut.Map<EncryptionDto>(contract);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<EncryptionDto>(result);
        Assert.Equal(result.EncryptionMethod, EncryptionMethod.AES);
        Assert.Null(result.EncryptionOptions);
        Assert.Equal(result.Key, contract.Key);
        Assert.Equal(result.Salt, contract.Salt);
        Assert.Equal(result.Value, contract.Value);
    }
}
