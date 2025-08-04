using UrlShortener.Domain;
using UrlShortener.Infrastructure;

namespace UrlShortener.Application;

public interface IUrlRepository
{
    void Add(UrlMapping urlMapping);
    UrlMapping GetByShortUrl(string shortUrl);
}

