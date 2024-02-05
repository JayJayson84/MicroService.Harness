using System.Reflection;
using MicroService.Configuration.Extensions;
using MicroService.Configuration.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace MicroService.Configuration.WebApi;

public class WebApiConfiguration
{
    private readonly List<Action<IServiceCollection, IConfiguration>> _serviceConfigurationActions = [];
    private readonly List<Action<IMassTransitConfigurationBuilder, IConfiguration>> _massTransitConfigurationActions = [];

    public WebApiConfiguration ConfigureServices(Action<IServiceCollection, IConfiguration> configurationAction)
    {
        _serviceConfigurationActions.Add(configurationAction);
        return this;
    }

    public WebApiConfiguration ConfigureMassTransit(Action<IMassTransitConfigurationBuilder, IConfiguration> registerConsumersAction)
    {
        _massTransitConfigurationActions.Add(registerConsumersAction);
        return this;
    }

    public void Run(AssemblyName assemblyName)
    {
        var args = Environment.GetCommandLineArgs();
        var builder = WebApplication.CreateBuilder(args);
        var config = builder.Configuration.AddDefaultAppConfiguration(args).Build();

        RegisterServices(builder.Services, config);

        var mvcBuilder = builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        if (builder.Environment.IsDevelopment() || builder.Environment.IsStaging())
        {
            mvcBuilder.AddNewtonsoftJson(setup =>
            {
                // Swagger - Verbose enums
                setup.SerializerSettings.Converters.Add(new StringEnumConverter
                {
                    NamingStrategy = new DefaultNamingStrategy()
                });
            });

            builder.Services
                .AddSwaggerGenNewtonsoftSupport()
                .AddSwaggerGen(opt =>
                {
                    // Swagger - XML Comments
                    var xmlFile = $"{assemblyName.Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    opt.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

                    // Swagger - Group enums within parent
                    opt.UseInlineDefinitionsForEnums();
                });
        }

        // Configure Kestrel for HTTPS
        if ((builder.Environment.IsDevelopment() || builder.Environment.IsStaging()) && config["ASPNETCORE_URLS"]?.Contains("https://+:5001") == true)
        {
            builder.WebHost.ConfigureKestrel(options =>
            {
                if (config["ASPNETCORE_URLS"]?.Contains("http://+:5000") == true)
                {
                    options.ListenAnyIP(5000);
                }
                
                options.ListenAnyIP(5001, listenOptions =>
                {
                    listenOptions.UseHttps($"/app/cert/{config["SSL_CERT_NAME"]}", config["SSL_CERT_KEY"]);
                });
            });
        }

        var app = builder.Build();
        if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        if (builder.Environment.IsProduction())
        {
            app.UseHttpsRedirection();
        }

        // Allow any website host to communicate with the API when testing.
        if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
        {
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        }

        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }

    private ServiceProvider RegisterServices(IServiceCollection serviceCollection, IConfiguration config)
    {
        serviceCollection.AddAzureAppConfiguration();
        serviceCollection.AddMassTransit(builder =>
        {
            builder.SetConfiguration(config);

            foreach (var action in _massTransitConfigurationActions)
            {
                action(builder, config);
            }
        });

        foreach (var action in _serviceConfigurationActions)
        {
            action(serviceCollection, config);
        }

        return serviceCollection.BuildServiceProvider();
    }

    public static WebApiConfiguration CreateBuilder() => new();
}
