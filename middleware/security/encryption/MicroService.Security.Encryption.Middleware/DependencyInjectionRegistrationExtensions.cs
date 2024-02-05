using MicroService.Security.Encryption.Factories;
using MicroService.Security.Encryption.Interfaces;
using MicroService.Security.Encryption.Middleware.Orchestrators.Implementation;
using MicroService.Security.Encryption.Middleware.Orchestrators.Interfaces;
using MicroService.Security.Encryption.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MicroService.Security.Encryption.Middleware;

/// <summary>
/// Register project dependencies with the service collection.
/// </summary>
public static class DependencyInjectionRegistrationExtensions
{
    /// <summary>
    /// Register encryption factories and services with the service collection.
    /// </summary>
    public static void AddEncryptionMiddleware(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DependencyInjectionRegistrationExtensions));
        services.AddSingleton<IEncryptionOrchestrator, EncryptionOrchestrator>();
        services.AddSingleton<IEncryptionServiceFactory, EncryptionServiceFactory>();
        services.AddTransient<IEncryptionService, EncryptionService>();
    }

    /// <summary>
    /// Register encryption services with the service collection.
    /// </summary>
    public static void AddEncryptionServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DependencyInjectionRegistrationExtensions));
        services.AddSingleton<IEncryptionOrchestrator, EncryptionOrchestrator>();
        services.AddTransient<IEncryptionService, EncryptionService>();
    }

    /// <summary>
    /// Register encryption factories with the service collection.
    /// </summary>
    public static void AddEncryptionFactories(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DependencyInjectionRegistrationExtensions));
        services.AddSingleton<IEncryptionOrchestrator, EncryptionOrchestrator>();
        services.AddSingleton<IEncryptionServiceFactory, EncryptionServiceFactory>();
    }
}
