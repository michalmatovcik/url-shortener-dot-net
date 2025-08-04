namespace UrlShortener.Application;

public interface IUrlService
{
    Task<string> ShortenUrlAsync(string originalUrl);
    Task<string> GetOriginalUrlAsync(string shortUrl);
}