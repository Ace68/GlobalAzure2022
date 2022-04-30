using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GlobalAzure2022.Modules.Production.Extensions.JsonRequests;
using Newtonsoft.Json;
using Xunit;

namespace GlobalAzure2022.Production.Tests;

public class ProductionTest : BaseTest
{
    [Fact]
    private async Task Can_Get_Greetings_FromProduction()
    {
        var request = new GreetingsRequest
        {
            Name = "Alberto"
        };
        var response = await Client.PostAsync("/production/",
            new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

        Assert.True(response.IsSuccessStatusCode);
    }
}