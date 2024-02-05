using AutoMapper;
using MicroService.Security.Encryption.Enums;

namespace MicroService.Security.Encryption.Middleware.Mappers;

internal class EncryptionMethodConverter : ITypeConverter<Contracts.EncryptionMethod, EncryptionMethod>
{
    public EncryptionMethod Convert(Contracts.EncryptionMethod source, EncryptionMethod destination, ResolutionContext context)
    {
        return source switch
        {
            Contracts.EncryptionMethod.AES => EncryptionMethod.AES,
            Contracts.EncryptionMethod.DES => EncryptionMethod.DES,
            Contracts.EncryptionMethod.RC2 => EncryptionMethod.RC2,
            Contracts.EncryptionMethod.TripleDES => EncryptionMethod.TripleDES,
            _
            => EncryptionMethod.NotSet
        };
    }
}
