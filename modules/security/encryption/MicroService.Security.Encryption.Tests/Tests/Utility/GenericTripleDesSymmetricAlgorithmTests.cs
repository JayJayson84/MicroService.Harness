using System.Security.Cryptography;
using MicroService.Security.Encryption.Models;
using SymmetricAlgorithm = MicroService.Security.Encryption.Utility.SymmetricAlgorithm;

namespace MicroService.Security.Encryption.Tests.Utility;

public class GenericTripleDesSymmetricAlgorithmTests
{

    [Fact]
    public void GivenAValueAndKey_WhenEncryptedAndDecrypted_ThenTheDecryptedStringShouldEqualTheOriginalValue()
    {
        // Arrange
        var value = ValueProvider.Value;
        var key = ValueProvider.Key;

        // Act
        var encrypted = SymmetricAlgorithm.EncryptString<TripleDES, TripleDesOptions>(value, key);
        var decrypted = SymmetricAlgorithm.DecryptString<TripleDES, TripleDesOptions>(encrypted!, key);

        // Assert
        Assert.Equal(decrypted, value);
    }

    [Fact]
    public void GivenAValueAndKeyAndSalt_WhenEncryptedAndDecrypted_ThenTheDecryptedStringShouldEqualTheOriginalValue()
    {
        // Arrange
        var value = ValueProvider.Value;
        var key = ValueProvider.Key;
        var salt = ValueProvider.Salt;

        // Act
        var encrypted = SymmetricAlgorithm.EncryptString<TripleDES, TripleDesOptions>(value, key, salt);
        var decrypted = SymmetricAlgorithm.DecryptString<TripleDES, TripleDesOptions>(encrypted!, key, salt);

        // Assert
        Assert.Equal(decrypted, value);
    }

}
