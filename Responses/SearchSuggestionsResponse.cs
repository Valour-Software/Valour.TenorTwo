using System.Text.Json.Serialization;

namespace Valour.TenorTwo.Responses;

public class SearchSuggestionsResponse
{
    [JsonPropertyName("results")]
    public string[] Suggestions { get; set; }
}