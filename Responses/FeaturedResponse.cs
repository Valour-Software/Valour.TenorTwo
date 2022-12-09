using System.Text.Json.Serialization;
using Valour.TenorTwo.Models;

namespace Valour.TenorTwo.Responses;

public class FeaturedResponse
{
    [JsonPropertyName("next")]
    public string NextPosition { get; set; }
    
    [JsonPropertyName("results")]
    public List<Media> Results { get; set; }
}