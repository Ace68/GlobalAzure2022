using System.Text.Json;
using GlobalAzure2022.Modules.Production.Extensions.JsonResponses;
using Xunit;

namespace GlobalAzure2022.Modules.Production.Tests
{
    public class ProductionModuleTest
    {
        [Fact]
        public void Can_Serialize_And_Deserialize_GreetingsMessage()
        {
            var body = "{\"message\":\"Hello from Production\"}";

            var deserializedMessage = JsonSerializer.Deserialize<ProductionGreetings>(body);

            Assert.Equal("Hello from Production", deserializedMessage?.Message);
        }
    }
}