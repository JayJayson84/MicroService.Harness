using AutoMapper;
using MicroService.Components.Tests.DSL.Subjects;
using MicroService.Components.Tests.Fakes;

namespace MicroService.Components.Tests.DSL.Builders;

public class MapperTestBuilder<TProfile> where TProfile : Profile
{
    private readonly List<Type> _mapperProfileTypes = [];
    private bool _createResolutionContext = false;

    public MapperTestBuilder()
    {
        _mapperProfileTypes.Add(typeof(TProfile));
    }

    public MapperTestBuilder<TProfile> WithProfile<TProfileItem>() where TProfileItem : Profile
    {
        _mapperProfileTypes.Add(typeof(TProfileItem));

        return this;
    }

    public MapperTestBuilder<TProfile> WithResolutionContext()
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

    public static MapperTestBuilder<TProfile> ConfigureTests() => new();
}
