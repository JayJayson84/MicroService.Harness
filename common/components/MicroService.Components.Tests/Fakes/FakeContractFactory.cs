using MicroService.Components.Tests.Fakes.Builders;

namespace MicroService.Components.Tests.Fakes;

public class FakeContractFactory
{
    public static FakeEncryptionContractBuilder CreateEncryptionContract(bool addMockData = false) => FakeEncryptionContractBuilder.CreateBuilder(addMockData);
}
