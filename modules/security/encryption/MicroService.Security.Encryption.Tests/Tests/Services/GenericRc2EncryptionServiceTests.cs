using System.Security.Cryptography;
using MicroService.Security.Encryption.Tests.DSL.Builders;
using MicroService.Security.Encryption.Tests.Utility;

namespace MicroService.Security.Encryption.Tests.Services;

public class GenericRc2EncryptionServiceTests
{

    [Fact]
    public void GivenAValueAndKey_WhenEncryptedAndDecrypted_ThenTheDecryptedStringShouldEqualTheOriginalValue()
    {
        // Arrange
        var value = ValueProvider.Value;
        var key = ValueProvider.Key;
        var sut = EncryptionServiceTestBuilder<RC2>
            .ConfigureTests()
            .Build()
            .EncryptionService;

        // Act
        var encrypted = sut.EncryptString(value, key);
        var decrypted = sut.DecryptString(encrypted!, key);

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
        var sut = EncryptionServiceTestBuilder<RC2>
            .ConfigureTests()
            .Build()
            .EncryptionService;

        // Act
        var encrypted = sut.EncryptString(value, key, salt);
        var decrypted = sut.DecryptString(encrypted!, key, salt);

        // Assert
        Assert.Equal(decrypted, value);
    }

}
