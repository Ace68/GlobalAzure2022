using System.Threading.Tasks;
using Xunit;

namespace GlobalAzure2022.Pubs.Tests;

public class PubsTest : BaseTest
{
    [Fact]
    private async Task Can_Get_Greetings_FromPubs()
    {
        var response = await Client.GetAsync("/pubs/");

        Assert.True(response.IsSuccessStatusCode);

        var body = await response.Content.ReadAsStringAsync();

        Assert.Equal("Hello from Pubs", body);
    }
}