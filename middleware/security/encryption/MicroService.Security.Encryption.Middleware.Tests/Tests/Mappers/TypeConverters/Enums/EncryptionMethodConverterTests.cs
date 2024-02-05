using MicroService.Security.Encryption.Enums;
using MicroService.Security.Encryption.Middleware.Mappers;

namespace MicroService.Security.Encryption.Middleware.Tests.Tests.Mappers.TypeConverters.Enums;

public class EncryptionMethodConverterTests
{
    [Theory]
    [InlineData(null, EncryptionMethod.NotSet)]
    [InlineData(Contracts.EncryptionMethod.AES, EncryptionMethod.AES)]
    [InlineData(Contracts.EncryptionMethod.DES, EncryptionMethod.DES)]
    [InlineData(Contracts.EncryptionMethod.RC2, EncryptionMethod.RC2)]
    [InlineData(Contracts.EncryptionMethod.TripleDES, EncryptionMethod.TripleDES)]
    public void EncryptionMethodConverter_EncryptionMethod_ResolvesToEncryptionMethod(Contracts.EncryptionMethod encryptionMethod, EncryptionMethod expectedEncryptionMethod)
    {
        // Arrange
        var sut = new EncryptionMethodConverter();

        // Act
        var result = sut.Convert(encryptionMethod, expectedEncryptionMethod, null!);

        // Assert
        Assert.Equal(result, expectedEncryptionMethod);
    }
}
