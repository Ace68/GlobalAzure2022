using System.Text.Json.Serialization;

namespace GlobalAzure2022.Modules.Production.Extensions.JsonRequests;

public class GreetingsRequest
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}