namespace Valour.TenorTwo.Models;

/// <summary>
/// Media formats are the various formats that Tenor can return for a given piece of media
/// </summary>
public enum MediaFormatType
{
    /// <summary>
	/// Resolution and size: High quality GIF format, largest file size available
	/// Dimensions: Original upload dimensions (no limits)
	/// Usage Notes: Use this size for GIF shares on desktop
    /// </summary>
	gif,
	/// <summary>
	/// Resolution and size: small reduction in size of the GIF format
	/// Dimensions: Original upload dimensions (no limits) but much higher compression rate
	/// Usage Notes: Use this size for GIF previews on desktop
	/// </summary>
	mediumgif,

	/// <summary>
	/// Resolution and size: reduced size of the GIF format
	/// Dimensions: Up to 220 pixels wide, Height scaled with aspect ratio preserved
	/// Usage Notes: Use this size for GIF previews and shares on mobile
	/// </summary>
	tinygif,

	/// <summary>
	/// Resolution and size: smallest size of the GIF format
	/// Dimensions: Up to 90 pixels tall, Width scaled with aspect ratio preserved
	/// Usage Notes: Use this size for GIF previews on mobile
	/// </summary>
	nanogif,
	
	/// <summary>
	/// Resolution and size: highest quality video format, largest of the video formats, but smaller than GIF
	/// Dimensions: Similar to gif, but padded to fit video container specifications (usually 8-pixel increments)
	/// Usage Notes: Use this size for MP4 previews and shares on desktop
	/// </summary>
	mp4,

	/// <summary>
	/// Resolution and size: highest quality video format, larger in size than mp4
	/// Dimensions: Same as mp4
	/// Usage Notes: Use this size for mp4 shares if you want the video clip to run a few times rather than only once
	/// </summary>
	loopedmp4,

	/// <summary>
	/// Resolution and size: reduced size of the mp4 format
	/// Dimensions: Variable width and height, with maximum bounding box of 320x320
	/// Usage Notes: Use this size for mp4 previews and shares on mobile
	/// </summary>
	tinymp4,

	/// <summary>
	/// Resolution and size: smallest size of the mp4 format
	/// Dimensions: Variable width and height, with maximum bounding box of 150x150
	/// Usage Notes: Use this size for mp4 previews on mobile
	/// </summary>
	nanomp4,

	/// <summary>
	/// Resolution and size: Lower quality video format, smaller in size than MP4
	/// Dimensions: Same as mp4
	/// Usage Notes: Use this size for webm previews and shares on desktop
	/// </summary>
	webm,

	/// <summary>
	/// Resolution and size: reduced size of the webm format
	/// Dimensions: Same as tinymp4
	/// Usage Notes: Use this size for GIF shares on mobile
	/// </summary>
	tinywebm,

	/// <summary>
	/// Resolution and size: smallest size of the webm format
	/// Dimensions: Same as nanomp4
	/// Usage Notes: Use this size for GIF previews on mobile
	/// </summary>
	nanowebm
}