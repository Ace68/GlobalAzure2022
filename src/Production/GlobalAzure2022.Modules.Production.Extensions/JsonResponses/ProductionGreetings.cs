using System.Text.Json.Serialization;

namespace GlobalAzure2022.Modules.Production.Extensions.JsonResponses;

public class ProductionGreetings
{
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
}