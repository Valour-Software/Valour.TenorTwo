using System.Text.Json.Serialization;
using Valour.TenorTwo.Models;

namespace Valour.TenorTwo.Responses;

public class MediaResponse
{
    /// <summary>
    ///     the most relevant GIFs for the requested search term - Sorted by relevancy Rank
    /// </summary>
    [JsonPropertyName("results")]
    public Media[] Results { get; set; }
    
    /// <summary>
    ///     a position identifier to use with the next API query to retrieve the next set of results, or null if there are no
    ///     further results.
    /// </summary>
    [JsonPropertyName("next")]
    public string NextPosition { get; set; }
    
    
}