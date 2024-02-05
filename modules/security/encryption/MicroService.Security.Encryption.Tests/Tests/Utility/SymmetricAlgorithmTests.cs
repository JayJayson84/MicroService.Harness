using MicroService.Security.Encryption.Enums;
using MicroService.Security.Encryption.Utility;

namespace MicroService.Security.Encryption.Tests.Utility;

public class SymmetricAlgorithmTests
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

        // Act
        var encrypted = SymmetricAlgorithm.EncryptString(value, key, encryptionMethod);
        var decrypted = SymmetricAlgorithm.DecryptString(encrypted!, key, encryptionMethod);

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

        // Act
        var encrypted = SymmetricAlgorithm.EncryptString(value, key, salt, encryptionMethod);
        var decrypted = SymmetricAlgorithm.DecryptString(encrypted!, key, salt, encryptionMethod);

        // Assert
        Assert.Equal(decrypted, value);
    }

}
