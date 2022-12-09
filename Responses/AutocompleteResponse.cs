using System.Text.Json.Serialization;

namespace Valour.TenorTwo.Responses;

public class AutocompleteResponse
{
    [JsonPropertyName("results")]
    public string[] Suggestions { get; set; }
}