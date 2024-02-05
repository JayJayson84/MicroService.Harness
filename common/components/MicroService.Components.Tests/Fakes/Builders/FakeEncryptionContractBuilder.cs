using MicroService.Security.Encryption.Contracts;

namespace MicroService.Components.Tests.Fakes.Builders;

public class FakeEncryptionContractBuilder
{
    private EncryptionMethod _encryptionMethod;
    private EncryptionOperation _encryptionOperation;
    private EncryptionOptions? _encryptionOptions;
    private string _key = null!;
    private string? _salt;
    private string _value = null!;

    public FakeEncryptionContractBuilder(bool addMockData = false)
    {
        if (!addMockData) return;

        _encryptionMethod = EncryptionMethod.AES;
        _encryptionOperation = EncryptionOperation.Encrypt;
        _encryptionOptions = null;
        _key = nameof(EncryptionContract.Key);
        _salt = nameof(EncryptionContract.Salt);
        _value = nameof(EncryptionContract.Value);
    }

    public FakeEncryptionContractBuilder WithEncryptionMethod(EncryptionMethod encryptionMethod)
    {
        _encryptionMethod = encryptionMethod;

        return this;
    }

    public FakeEncryptionContractBuilder WithEncryptionOperation(EncryptionOperation encryptionOperation)
    {
        _encryptionOperation = encryptionOperation;

        return this;
    }
    public FakeEncryptionContractBuilder WithEncryptionOptions(EncryptionOptions encryptionOptions)
    {
        _encryptionOptions = encryptionOptions;

        return this;
    }

    public FakeEncryptionContractBuilder WithKey(string key)
    {
        _key = key;

        return this;
    }

    public FakeEncryptionContractBuilder WithSalt(string? salt)
    {
        _salt = salt;

        return this;
    }

    public FakeEncryptionContractBuilder WithValue(string value)
    {
        _value = value;

        return this;
    }

    public EncryptionContract Build()
    {
        return new()
        {
            EncryptionMethod = _encryptionMethod,
            EncryptionOperation = _encryptionOperation,
            EncryptionOptions = _encryptionOptions,
            Key = _key,
            Salt = _salt,
            Value = _value
        };
    }

    public static FakeEncryptionContractBuilder CreateBuilder(bool addMockData = false) => new(addMockData);
}
