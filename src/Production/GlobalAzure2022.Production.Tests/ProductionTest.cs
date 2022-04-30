using System.Text.Json;
using System.Threading.Tasks;
using GlobalAzure2022.Modules.Production.Extensions.JsonResponses;
using Xunit;

namespace GlobalAzure2022.Production.Tests;

public class ProductionTest : BaseTest
{
    [Fact]
    private async Task Can_Get_Greetings_FromProduction()
    {
        var response = await Client.GetAsync("/production/");

        Assert.True(response.IsSuccessStatusCode);

        var body = await response.Content.ReadAsStringAsync();
        var message = JsonSerializer.Deserialize<ProductionGreetings>(body);

        Assert.Equal("Hello from Production", message.Message);
    }
}