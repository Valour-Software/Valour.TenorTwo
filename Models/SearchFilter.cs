namespace Valour.TenorTwo.Models;

/// <summary>
/// Search filter types control the type of media being returned.
/// If not defined, returns gifs.
/// </summary>
public class SearchFilter
{
    /// <summary>
    /// Will only return stickers
    /// </summary>
    public static readonly SearchFilter Sticker = new SearchFilter(SearchFilterType.Sticker);
    public static readonly SearchFilter StickerStatic = new SearchFilter(SearchFilterType.StickerStatic);
    public static readonly SearchFilter StickerAnimated = new SearchFilter(SearchFilterType.StickerAnimated);

    /// <summary>
    /// Used to efficiently map from enum value to string value
    /// </summary>
    private static readonly string[] ValueMap = {
        StickerValue,
        StickerStaticValue,
        StickerAnimatedValue
    };
    
    private const string StickerValue = "sticker";
    private const string StickerStaticValue = "sticker,static";
    private const string StickerAnimatedValue = "sticker,-static";
    
    /// <summary>
    /// Internal type of this filter instance
    /// </summary>
    private readonly SearchFilterType _type;
    
    public SearchFilter(SearchFilterType type)
    {
        _type = type;
    }

    public override string ToString() => ValueMap[(int)_type];
}

public enum SearchFilterType
{
    /// <summary>
    /// Will only return stickers
    /// </summary>
    Sticker,
    
    /// <summary>
    /// Will only return static (non-animated) stickers
    /// </summary>
    StickerStatic,
    
    /// <summary>
    /// Will only return animated stickers
    /// </summary>
    StickerAnimated
}