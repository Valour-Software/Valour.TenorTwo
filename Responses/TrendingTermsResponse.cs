using System.Text.Json.Serialization;

namespace Valour.TenorTwo.Responses;

public class TrendingTermsResponse
{
    [JsonPropertyName("results")]
    public string[] Terms { get; set; }
}