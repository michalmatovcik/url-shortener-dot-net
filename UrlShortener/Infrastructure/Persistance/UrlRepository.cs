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
        _context.UrlMappings.Add(urlMapping); //CR - moze byt async ".AddAsync(..., cancellationToken)" + je tam podporovany aj CancellationToken
    }

    public UrlMapping GetByShortUrl(string shortUrl)
    {
        return _context.UrlMappings.FirstOrDefault(um => um.ShortenedUrl == shortUrl) //CR - moze byt async ".FirstOrDefaultAsync(..., cancellationToken)"
               ?? throw new KeyNotFoundException($"Short URL '{shortUrl}' not found.");
    }
}