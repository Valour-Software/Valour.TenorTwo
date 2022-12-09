using System.Globalization;
using System.Net.Http.Json;
using System.Text;
using Valour.TenorTwo.Models;
using Valour.TenorTwo.Responses;

namespace Valour.TenorTwo;

/// <summary>
/// The client for interacting with the Tenor API
/// </summary>
public class TenorClient
{
    /// <summary>
    /// Base address used to reach Tenor API
    /// </summary>
    private const string BaseAddress = "https://tenor.googleapis.com/v2/";
    
    /// <summary>
    /// Internal store of API key
    /// </summary>
    private readonly string _apiKey;

    /// <summary>
    /// The ISO 3166-1 country code
    /// </summary>
    private readonly string _country;

    /// <summary>
    /// The default language to interpret the search string (xx_YY).
    /// xx is the language's ISO 639-1 language code, while the optional
    /// _YY value is the two-letter ISO 3166-1 country code.
    /// </summary>
    private readonly string _locale;
    
    /// <summary>
    /// Internal Http client
    /// </summary>
    private readonly HttpClient _http;

    /// <summary>
    /// A value used to differentiate requests between integrations
    /// </summary>
    private readonly string _clientKey;
    
    public TenorClient(string key, string clientKey = null, string country = null, string locale = null, HttpClient http = null)
    {
        _apiKey = key;
        _clientKey = clientKey;

        if (http is not null)
        {
            _http = http;
        }
        else
        {
            _http = new HttpClient();
            _http.BaseAddress = new Uri(BaseAddress);
        }
        
        var culture = CultureInfo.CurrentCulture;

        _country = country ?? (new RegionInfo(culture.Name)).TwoLetterISORegionName;
        _locale = locale ?? $"{culture.TwoLetterISOLanguageName}_{_country}";
    }

    public async Task<MediaResponse> Search(
        string query,
        int limit = 20,
        string position = null,
        List<MediaFormatType> formatFilter = null, 
        ContentFilter? contentFilter = null, 
        SearchFilter searchFilter = null,
        AspectRatio? aspectRatio = null,
        bool? random = null)
    {
        var sb = new StringBuilder(64);
        
        // Address and endpoint
        sb.Append(BaseAddress);
        sb.Append(Endpoints.Search);
        // Key
        sb.Append("?key=");
        sb.Append(_apiKey);
        // Query
        sb.Append("&q=");
        sb.Append(query);
        // Country
        sb.Append("&country=");
        sb.Append(_country);
        // Locale
        sb.Append("&locale=");
        sb.Append(_locale);
        // Limit
        sb.Append("&limit=");
        sb.Append(limit);
        
        if (_clientKey is not null)
        {
            sb.Append("&client_key=");
            sb.Append(_clientKey);
        }

        if (searchFilter is not null)
        {
            sb.Append("&searchfilter=");
            sb.Append(searchFilter);
        }

        if (contentFilter is not null)
        {
            sb.Append("&contentfilter=");
            sb.Append(contentFilter);
        }
        
        if (formatFilter is not null)
        {
            sb.Append("&media_filter=");
            sb.Append(string.Join(',', formatFilter));
        }

        if (aspectRatio is not null)
        {
            sb.Append("&ar_range=");
            sb.Append(aspectRatio);
        }

        if (random is not null)
        {
            sb.Append("&random=");
            sb.Append(random);
        }

        if (position is not null)
        {
            sb.Append("&pos=");
            sb.Append(position);
        }

        return await _http.GetFromJsonAsync<MediaResponse>(sb.ToString());
    }
    
}