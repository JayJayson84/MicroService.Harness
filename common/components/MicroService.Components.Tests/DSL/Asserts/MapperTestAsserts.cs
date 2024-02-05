using MicroService.Components.Tests.DSL.Subjects;

namespace MicroService.Components.Tests.DSL.Asserts;

public class MapperTestAsserts(MapperSut sut)
{
    readonly MapperSut _sut = sut;

    public MapperSut ConfigurationIsValid()
    {
        _sut.MapperConfiguration.AssertConfigurationIsValid();

        return _sut;
    }
}
