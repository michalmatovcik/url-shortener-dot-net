using Microsoft.EntityFrameworkCore.ChangeTracking;
using UrlShortener.Domain;
using UrlShortener.Infrastructure;

namespace UrlShortener.Application;

public interface IUrlRepository
{
    Task<UrlMapping> AddAsync(UrlMapping urlMapping, CancellationToken cancellationToken = default);
    Task<UrlMapping?> GetByUrlHashAsync(string urlHash, CancellationToken cancellationToken = default);
    Task<UrlMapping?> GetByUrlAsync(string url, CancellationToken cancellationToken = default);
}

