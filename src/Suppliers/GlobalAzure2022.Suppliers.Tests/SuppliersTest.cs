using System.Threading.Tasks;
using Xunit;

namespace GlobalAzure2022.Suppliers.Tests;

public class SuppliersTest : BaseTest
{
    [Fact]
    private async Task Can_Get_Greetings_FromSuppliers()
    {
        var response = await Client.GetAsync("/suppliers/");

        Assert.True(response.IsSuccessStatusCode);

        var body = await response.Content.ReadAsStringAsync();

        Assert.Equal("\"Hello from Suppliers\"", body);
    }
}