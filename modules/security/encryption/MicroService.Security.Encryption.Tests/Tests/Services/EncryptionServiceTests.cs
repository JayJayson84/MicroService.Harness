using MicroService.Security.Encryption.Enums;
using MicroService.Security.Encryption.Tests.DSL.Builders;
using MicroService.Security.Encryption.Tests.Utility;

namespace MicroService.Security.Encryption.Tests.Services;

public class EncryptionServiceTests
{

    [Theory]
    [InlineData(EncryptionMethod.AES)]
    [InlineData(EncryptionMethod.DES)]
    [InlineData(EncryptionMethod.RC2)]
    [InlineData(EncryptionMethod.TripleDES)]
    public void GivenAnEncryptionMethodAndValueAndKey_WhenEncryptedAndDecrypted_ThenTheDecryptedStringShouldEqualTheOriginalValue(EncryptionMethod encryptionMethod)
    {
        // Arrange
        var value = ValueProvider.Value;
        var key = ValueProvider.Key;
        var sut = EncryptionServiceTestBuilder
            .ConfigureTests()
            .WithEncryptionMethod(encryptionMethod)
            .Build()
            .EncryptionService;

        // Act
        var encrypted = sut.EncryptString(value, key);
        var decrypted = sut.DecryptString(encrypted!, key);

        // Assert
        Assert.Equal(decrypted, value);
    }

    [Theory]
    [InlineData(EncryptionMethod.AES)]
    [InlineData(EncryptionMethod.DES)]
    [InlineData(EncryptionMethod.RC2)]
    [InlineData(EncryptionMethod.TripleDES)]
    public void GivenAnEncryptionMethodAndValueAndKeyAndSalt_WhenEncryptedAndDecrypted_ThenTheDecryptedStringShouldEqualTheOriginalValue(EncryptionMethod encryptionMethod)
    {
        // Arrange
        var value = ValueProvider.Value;
        var key = ValueProvider.Key;
        var salt = ValueProvider.Salt;
        var sut = EncryptionServiceTestBuilder
            .ConfigureTests()
            .WithEncryptionMethod(encryptionMethod)
            .Build()
            .EncryptionService;

        // Act
        var encrypted = sut.EncryptString(value, key, salt);
        var decrypted = sut.DecryptString(encrypted!, key, salt);

        // Assert
        Assert.Equal(decrypted, value);
    }
}
