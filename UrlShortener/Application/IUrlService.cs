namespace UrlShortener.Application;

public interface IUrlService
{
    Task<string> ShortenUrlAsync(string originalUrl, CancellationToken cancellationToken = default);
    Task<string> GetFullUrlAsync(string urlHash, CancellationToken cancellationToken = default);
}