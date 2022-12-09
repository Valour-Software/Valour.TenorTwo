namespace Valour.TenorTwo.Models;

/// <summary>
/// Content filters control the maturity level of responses
/// </summary>
public enum ContentFilter
{
    /// <summary>
    /// G
    /// </summary>
    high,

    /// <summary>
    /// G and PG
    /// </summary>
    medium,

    /// <summary>
    /// G, PG, and PG-13
    /// </summary>
    low,

    /// <summary>
    /// G, PG, PG-13, and R (no nudity)
    /// </summary>
    off
}