namespace Valour.TenorTwo;

public class Endpoints
{
    /// <summary>
    /// Get a JSON object that contains a list of the most relevant GIFs for a given set of
    /// search terms, categories, emojis, or any combination of these.
    /// </summary>
    public const string Search = "search";

    /// <summary>
    /// Get a JSON object that contains a list of the current global featured GIFs.
    /// Tenor updates the featured stream regularly throughout the day.
    /// </summary>
    public const string Featured = "featured";

    /// <summary>
    /// Get a JSON object that contains a list of GIF categories associated with the provided type.
    /// Each category includes a corresponding search URL to use if the user clicks on the category.
    /// The search URL includes any parameters from the original call to the Categories endpoint.
    /// </summary>
    public const string Categories = "categories";

    /// <summary>
    /// Get a JSON object that contains a list of alternative search terms for a given search term.
    /// </summary>
    public const string Suggestions = "search_suggestions";

    /// <summary>
    /// Get a JSON object that contains a list of alternative search terms for a given search term.
    /// </summary>
    public const string AutoComplete = "autocomplete";

    /// <summary>
    /// Get a JSON object that contains a list of the current trending search terms. Tenor's AI updates the list hourly.
    /// </summary>
    public const string TrendingTerms = "trending_terms";

    /// <summary>
    /// Register a user's sharing of a GIF or sticker.
    /// </summary>
    public const string RegisterShare = "registershare";

    /// <summary>
    /// Get the GIFs, stickers, or a combination of the two for the specified IDs.
    /// </summary>
    public const string Posts = "posts";
}