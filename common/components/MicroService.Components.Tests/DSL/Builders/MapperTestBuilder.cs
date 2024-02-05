using AutoMapper;
using MicroService.Components.Tests.DSL.Subjects;
using MicroService.Components.Tests.Fakes;

namespace MicroService.Components.Tests.DSL.Builders;

public class MapperTestBuilder
{
    private readonly List<Type> _mapperProfileTypes = [];
    private bool _createResolutionContext = false;

    public MapperTestBuilder WithProfile<TProfile>() where TProfile : Profile
    {
        _mapperProfileTypes.Add(typeof(TProfile));

        return this;
    }

    public MapperTestBuilder WithResolutionContext()
    {
        _createResolutionContext = true;

        return this;
    }

    public MapperSut Build()
    {
        var mapperConfiguration = new MapperConfiguration(cfg =>
        {
            _mapperProfileTypes.ForEach(cfg.AddProfile);
        });

        var mapper = new Mapper(mapperConfiguration);
        var resolutionContext = _createResolutionContext
            ? FakeMapperFactory.CreateResolutionContext(mapper)
            : null;

        return new MapperSut()
        {
            MapperConfiguration = mapperConfiguration,
            Mapper = mapper,
            ResolutionContext = resolutionContext
        };
    }

    public static MapperTestBuilder ConfigureTests() => new();
}
