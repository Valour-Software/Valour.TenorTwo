using System.Text.Json.Serialization;

namespace Valour.TenorTwo.Models;

/// <summary>
/// A media response for a specific FormatType 
/// </summary>
public class MediaFormat
{
    /// <summary>
    /// A url to a preview image of the media source
    /// </summary>
    [JsonPropertyName("preview")]
    public string Preview { get; set; }
	
    /// <summary>
    /// A url to the media source
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }
	
    /// <summary>
    /// Width and height (in pixels)
    /// </summary>
    [JsonPropertyName("dims")] 
    public int[] Dims { get; set; }

    /// <summary>
    /// Size of file (in bytes)
    /// </summary>
    [JsonPropertyName("size")]
    public int Size { get; set; }
}