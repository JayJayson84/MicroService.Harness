using AutoMapper;
using MicroService.Components.Tests.DSL.Asserts;

namespace MicroService.Components.Tests.DSL.Subjects;

public class MapperSut
{
    public MapperSut()
    {
        Assert = new(this);
    }

    public MapperConfiguration MapperConfiguration { get; set; } = null!;
    public IMapper Mapper { get; set; } = null!;
    public ResolutionContext? ResolutionContext { get; set; } = null!;
    public MapperTestAsserts Assert { get; }
}
