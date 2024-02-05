using MassTransit;
using MassTransit.Testing;
using MicroService.Components.Tests.Fakes;
using MicroService.Logging.Logger;
using MicroService.Security.Encryption.Contracts;
using MicroService.Security.Encryption.Middleware;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroService.Security.Consumers.Tests.Consumers;

public class EncryptionConsumerTests
{
    [Fact]
    public async Task GivenConsumeIsInvoked_WhenEncryptionContractIsValid_ThenContractIsConsumedAndResponseIsValid()
    {
        // Arrange
        await using var provider = new ServiceCollection()
            .AddMassTransitTestHarness(x =>
            {
                var configuration = new ConfigurationBuilder().Build();

                x.AddSingleton<IConfiguration>(configuration);
                x.AddConsoleLogger(Logging.Enums.LoggerType.NLog);
                x.AddEncryptionMiddleware();
                x.AddConsumer<EncryptionConsumer>();
            })
            .BuildServiceProvider(true);

        var harness = provider.GetRequiredService<ITestHarness>();
        var consumerHarness = harness.GetConsumerHarness<EncryptionConsumer>();
        
        await harness.Start();
        
        var client = harness.GetRequestClient<EncryptionContract>();
        var contract = FakeContractFactory.CreateEncryptionContract(addMockData: true);

        // Act
        var result = await client.GetResponse<EncryptionResponse>(contract);

        // Assert
        Assert.True(await consumerHarness.Consumed.Any<EncryptionContract>());
        Assert.True(await harness.Consumed.Any<EncryptionContract>());
        Assert.IsType<EncryptionResponse>(result.Message);
    }
}
