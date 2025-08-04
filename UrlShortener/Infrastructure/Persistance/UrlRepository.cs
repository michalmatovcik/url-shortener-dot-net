using UrlShortener.Domain;
using UrlShortener.Infrastructure;

namespace UrlShortener.Application;

public class UrlRepository : IUrlRepository
{
    private readonly UrlDbContext _context;

    public UrlRepository(UrlDbContext context)
    {
        _context = context;
    }

    public void Add(UrlMapping urlMapping)
    {
        _context.UrlMappings.Add(urlMapping);
    }

    public UrlMapping GetByShortUrl(string shortUrl)
    {
        return _context.UrlMappings.FirstOrDefault(um => um.ShortenedUrl == shortUrl)
               ?? throw new KeyNotFoundException($"Short URL '{shortUrl}' not found.");
    }
}