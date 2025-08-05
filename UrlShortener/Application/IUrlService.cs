namespace UrlShortener.Application;

public interface IUrlService //CR - chyba registracia v program.cs
{
    Task<string> ShortenUrlAsync(string originalUrl);
    Task<string> GetOriginalUrlAsync(string shortUrl);
}