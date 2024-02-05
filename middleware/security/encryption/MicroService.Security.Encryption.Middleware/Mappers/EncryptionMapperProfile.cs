using AutoMapper;
using MicroService.Security.Encryption.Contracts;
using MicroService.Security.Encryption.Middleware.DTOs;
using MicroService.Security.Encryption.Models;

namespace MicroService.Security.Encryption.Middleware.Mappers;

internal class EncryptionMapperProfile : Profile
{
    public EncryptionMapperProfile() {
        CreateMap<EncryptionContract, EncryptionDto>()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Key))
            .ForMember(dest => dest.Salt, opt => opt.MapFrom(src => src.Salt))
            .ForMember(dest => dest.EncryptionMethod, opt => opt.MapFrom(src => src.EncryptionMethod))
            .ForMember(dest => dest.EncryptionOptions, opt => opt.MapFrom(src => src.EncryptionOptions));

        CreateMap<EncryptionOptions, SymmetricAlgorithmOptions>()
            .ForMember(dest => dest.BlockSize, opt => opt.MapFrom(src => src.BlockSize))
            .ForMember(dest => dest.CipherMode, opt => opt.MapFrom(src => src.CipherMode))
            .ForMember(dest => dest.DerivationIterations, opt => opt.MapFrom(src => src.DerivationIterations))
            .ForMember(dest => dest.KeySize, opt => opt.MapFrom(src => src.KeySize))
            .ForMember(dest => dest.PaddingMode, opt => opt.MapFrom(src => src.PaddingMode));
        
        CreateMap<EncryptionMethod, Enums.EncryptionMethod>()
            .ConvertUsing<EncryptionMethodConverter>();
    }
}
