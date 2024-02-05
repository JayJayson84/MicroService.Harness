using System.Reflection;

namespace MicroService.Security.Producers;

/// <summary>
/// Static members to access the root Assembly.
/// </summary>
public class AssemblyInfo
{
    /// <summary>
    /// Gets the currently loaded assembly in which the specified type is defined.
    /// </summary>
    /// <returns>The assembly in which the specified type is defined.</returns>
    /// <exception cref="ArgumentNullException"/>
    public static Assembly GetAssembly() => Assembly.GetAssembly(typeof(AssemblyInfo))!;

    /// <summary>
    /// Gets an AssemblyName for this assembly.
    /// </summary>
    /// <returns>An object that contains the fully parsed display name for this assembly.</returns>
    public static AssemblyName GetName() => Assembly.GetAssembly(typeof(AssemblyInfo))!.GetName();
}
