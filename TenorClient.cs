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
    private readonly string _country = "US";

    /// <summary>
    /// The default language to interpret the search string (xx_YY).
    /// xx is the language's ISO 639-1 language code, while the optional
    /// _YY value is the two-letter ISO 3166-1 country code.
    /// </summary>
    private readonly string _locale = "en_US";
    
    /// <summary>
    /// Internal Http client
    /// </summary>
    private readonly HttpClient _http;

    /// <summary>
    /// A value used to differentiate requests between integrations
    /// </summary>
    private readonly string _clientKey;

    public TenorClient(string key, string clientKey = null, string country = null, string locale = null,
        HttpClient http = null)
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

        try
        {
            var culture = CultureInfo.CurrentCulture;
            _country = country ?? (new RegionInfo(culture.Name)).TwoLetterISORegionName;
            _locale = locale ?? $"{culture.TwoLetterISOLanguageName}_{_country}";
        } 
        catch (Exception e)
        {
            // do nothing
        }
    }
        
    /// <summary>
    /// Returns the media for the given ids using the Tenor API
    /// </summary>
    public async Task<MediaResponse> Posts(
        IEnumerable<string> ids,
        int limit = 20,
        string position = null,
        List<MediaFormatType> formatFilter = null)
    {
        var sb = new StringBuilder(64);
        
        // Address and endpoint
        sb.Append(BaseAddress);
        sb.Append(Endpoints.Search);
        // Key
        sb.Append("?key=");
        sb.Append(_apiKey);
        // Query
        sb.Append("&ids=");
        sb.Append(string.Join(',', ids));
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
        
        if (formatFilter is not null)
        {
            sb.Append("&media_filter=");
            sb.Append(string.Join(',', formatFilter));
        }
        
        if (position is not null)
        {
            sb.Append("&pos=");
            sb.Append(position);
        }

        return await _http.GetFromJsonAsync<MediaResponse>(sb.ToString());
    }

    /// <summary>
    /// Used to search for media via the Tenor API
    /// </summary>
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
    
    /// <summary>
    /// Returns the trending media in the Tenor API
    /// </summary>
    public async Task<FeaturedResponse> Featured(
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
        sb.Append(Endpoints.Featured);
        // Key
        sb.Append("?key=");
        sb.Append(_apiKey);
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

        return await _http.GetFromJsonAsync<FeaturedResponse>(sb.ToString());
    }
    
    /// <summary>
    /// Returns the categories in the Tenor API
    /// </summary>
    public async Task<CategoriesResponse> Categories(
        CategoryType type = CategoryType.Featured,
        ContentFilter? contentFilter = null)
    {
        var sb = new StringBuilder(64);
        
        // Address and endpoint
        sb.Append(BaseAddress);
        sb.Append(Endpoints.Categories);
        // Key
        sb.Append("?key=");
        sb.Append(_apiKey);
        // Country
        sb.Append("&country=");
        sb.Append(_country);
        // Locale
        sb.Append("&locale=");
        sb.Append(_locale);
        // Type
        sb.Append("&type=");
        sb.Append(type);

        if (_clientKey is not null)
        {
            sb.Append("&client_key=");
            sb.Append(_clientKey);
        }

        if (contentFilter is not null)
        {
            sb.Append("&contentfilter=");
            sb.Append(contentFilter);
        }

        return await _http.GetFromJsonAsync<CategoriesResponse>(sb.ToString());
    }
    
    /// <summary>
    /// Returns search suggestions for the given query using the Tenor API
    /// </summary>
    public async Task<SearchSuggestionsResponse> SearchSuggestions(string query, int limit = 20)
    {
        var sb = new StringBuilder(64);
        
        // Address and endpoint
        sb.Append(BaseAddress);
        sb.Append(Endpoints.Suggestions);
        // Key
        sb.Append("?key=");
        sb.Append(_apiKey);
        // Country
        sb.Append("&country=");
        sb.Append(_country);
        // Locale
        sb.Append("&locale=");
        sb.Append(_locale);
        // Query
        sb.Append("&q=");
        sb.Append(query);
        // Limit
        sb.Append("&limit=");
        sb.Append(limit);

        if (_clientKey is not null)
        {
            sb.Append("&client_key=");
            sb.Append(_clientKey);
        }

        return await _http.GetFromJsonAsync<SearchSuggestionsResponse>(sb.ToString());
    }
    
    /// <summary>
    /// Returns autocomplete options for the given query using the Tenor API
    /// </summary>
    public async Task<AutocompleteResponse> Autocomplete(string query, int limit = 20)
    {
        var sb = new StringBuilder(64);
        
        // Address and endpoint
        sb.Append(BaseAddress);
        sb.Append(Endpoints.Suggestions);
        // Key
        sb.Append("?key=");
        sb.Append(_apiKey);
        // Country
        sb.Append("&country=");
        sb.Append(_country);
        // Locale
        sb.Append("&locale=");
        sb.Append(_locale);
        // Query
        sb.Append("&q=");
        sb.Append(query);
        // Limit
        sb.Append("&limit=");
        sb.Append(limit);

        if (_clientKey is not null)
        {
            sb.Append("&client_key=");
            sb.Append(_clientKey);
        }

        return await _http.GetFromJsonAsync<AutocompleteResponse>(sb.ToString());
    }
    
    /// <summary>
    /// Returns currently trending terms using the Tenor API
    /// </summary>
    public async Task<TrendingTermsResponse> TrendingTerms(int limit = 20)
    {
        var sb = new StringBuilder(64);
        
        // Address and endpoint
        sb.Append(BaseAddress);
        sb.Append(Endpoints.Suggestions);
        // Key
        sb.Append("?key=");
        sb.Append(_apiKey);
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

        return await _http.GetFromJsonAsync<TrendingTermsResponse>(sb.ToString());
    }

    /// <summary>
    /// Registers a share for the given media id
    /// Query should be the search term that led to the share
    /// </summary>
    public async Task RegisterShare(string id, string query = null)
    {
        var sb = new StringBuilder(64);
        
        // Address and endpoint
        sb.Append(BaseAddress);
        sb.Append(Endpoints.RegisterShare);
        // Key
        sb.Append("?key=");
        sb.Append(_apiKey);
        // Country
        sb.Append("&country=");
        sb.Append(_country);
        // Locale
        sb.Append("&locale=");
        sb.Append(_locale);
        // Id
        sb.Append("&id=");
        sb.Append(id);

        if (_clientKey is not null)
        {
            sb.Append("&client_key=");
            sb.Append(_clientKey);
        }

        if (query is not null)
        {
            sb.Append("&q=");
            sb.Append(query);
        }

        await _http.GetAsync(sb.ToString());
    }
    
}