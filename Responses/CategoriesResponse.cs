using System.Text.Json.Serialization;
using Valour.TenorTwo.Models;

namespace Valour.TenorTwo.Responses;

public class CategoriesResponse
{
    [JsonPropertyName("tags")]
    public List<Category> Categories { get; set; }
}