using System.Reflection;
using AutoMapper;

namespace MicroService.Components.Tests.Fakes;

public class FakeMapperFactory
{
    public static ResolutionContext? CreateResolutionContext(Mapper? mapper)
    {
        if (mapper == null) return null;

        var resolutionContextType = typeof(ResolutionContext);

        return (ResolutionContext?)resolutionContextType
            .Assembly
            .CreateInstance
            (
                typeName: resolutionContextType.FullName!,
                ignoreCase: false,
                bindingAttr: BindingFlags.Instance | BindingFlags.NonPublic,
                binder: null,
                args: [mapper, null!],
                culture: null,
                activationAttributes: null
            );
    }
}
