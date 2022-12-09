using System.Text.Json.Serialization;

namespace Valour.TenorTwo.Models;

/// <summary>
/// The media response returned by the Tenor API after a successful request
/// </summary>
public class Media
{
    /// <summary>
	/// Tenor result identifier
	/// </summary>
	[JsonPropertyName("id")]
	public string Id { get; set; }
	
	/// <summary>
	/// Title of the post.
	/// </summary>
	[JsonPropertyName("title")]
	public string Title { get; set; }
	
	/// <summary>
	/// A dictionary of media format type (stringified) to MediaFormat
	/// </summary>
	[JsonPropertyName("media_formats")]
	public Dictionary<string, MediaFormat> Formats { get; set; }
	
	/// <summary>
	/// A unix timestamp representing when this post was created.
	/// </summary>
	[JsonPropertyName("created")]
	public float Created { get; set; }

	/// <summary>
	/// True if this post contains audio (only video formats support audio, the gif image file format can not contain audio
	/// information).
	/// </summary>
	[JsonPropertyName("hasaudio")]
	public bool HasAudio { get; set; }

	/// <summary>
	/// An array of tags for the post
	/// </summary>
	[JsonPropertyName("tags")]
	public string[] Tags { get; set; }

	/// <summary>
	/// The description of the post.
	/// </summary>
	[JsonPropertyName("content_description")]
	public string Description { get; set; }

	/// <summary>
	/// The full URL to view the post on tenor.com.
	/// </summary>
	[JsonPropertyName("itemurl")]
	public string ItemUrl { get; set; }
	
	/// <summary>
	/// Returns true if this post contains captions.
	/// </summary>
	[JsonPropertyName("hascaption")]
	public bool HasCaption { get; set; }
	
	/// <summary>
	/// An array of flags for the post
	/// </summary>
	[JsonPropertyName("flags")]
	public string[] Flags { get; set; }

	/// <summary>
	/// The most common background pixel color of the content
	/// </summary>
	[JsonPropertyName("bg_color")]
	public string BackgroundColor { get; set; }

	/// <summary>
	/// A short URL to view the post on tenor.com.
	/// </summary>
	[JsonPropertyName("url")]
	public string Url { get; set; }

	/// <summary>
	/// Returns the media object for the given format
	/// </summary>
	public MediaFormat GetFormat(MediaFormatType format)
	{
		Formats.TryGetValue(format.ToString(), out var media);
		return media;
	}
}