using Microsoft.EntityFrameworkCore;
using UrlShortener.Application;
using UrlShortener.Domain;

namespace UrlShortener.Infrastructure.Persistence;

public class UrlRepository(UrlDbContext context) : IUrlRepository
{
    public async Task<UrlMapping> AddAsync(UrlMapping urlMapping, CancellationToken cancellationToken = default)
    {
        await context.UrlMappings.AddAsync(urlMapping, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return urlMapping;
    }

    public Task<UrlMapping?> GetByUrlHashAsync(string urlHash, CancellationToken cancellationToken = default)
    {
        return context.UrlMappings
            .FirstOrDefaultAsync(um => um.UrlHash == urlHash, cancellationToken);
    }

    public Task<UrlMapping?> GetByUrlAsync(string url, CancellationToken cancellationToken = default)
    {
        return context.UrlMappings
            .FirstOrDefaultAsync(um => um.Url == url, cancellationToken);
    }
}