namespace UrlShortener.Application;

public interface ICacheService
{
    Task<string?> GetAsync(string key);
    Task SetAsync(string key, string value);
}