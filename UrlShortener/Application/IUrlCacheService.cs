namespace UrlShortener.Application;

public interface IUrlCacheService
{
    Task<string?> GetUrlHashAsync(string url);
    Task SetAsync(string urlHash, string url);
}