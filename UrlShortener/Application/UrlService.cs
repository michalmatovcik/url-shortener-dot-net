using UrlShortener.Domain;

namespace UrlShortener.Application;

public class UrlService(
    IUrlCacheService cache,
    IUrlRepository repository,
    IBase62Encoder encoder)
    : IUrlService
{
    public async Task<string> ShortenUrlAsync(string url, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            throw new ArgumentException("URL cannot be null or empty.", nameof(url));
        }

        var existingMapping = await repository.GetByUrlAsync(url, cancellationToken);
        if (existingMapping != null)
        {
            return existingMapping.UrlHash;
        }

        var mapping = new UrlMapping
        {
            Url = url,
            UrlHash = await GetUnusedUrlHashAsync(cancellationToken)
        };

        await repository.AddAsync(mapping, cancellationToken);
        await cache.SetAsync(mapping.UrlHash, mapping.Url);

        return mapping.UrlHash;
    }

    public async Task<string> GetFullUrlAsync(string urlHash, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(urlHash))
        {
            throw new ArgumentException("URL hash cannot be null or empty.", nameof(urlHash));
        }

        var cachedUrl = await cache.GetUrlHashAsync(urlHash);
        if (cachedUrl != null)
        {
            return cachedUrl;
        }

        var existingMapping = await repository.GetByUrlHashAsync(urlHash, cancellationToken);
        if (existingMapping == null)
        {
            throw new KeyNotFoundException($"No URL found for hash: {urlHash}");
        }

        await cache.SetAsync(existingMapping.UrlHash, existingMapping.Url);

        return existingMapping.Url;
    }

    private async Task<string> GetUnusedUrlHashAsync(CancellationToken cancellationToken)
    {
        while (true)
        {
            var urlHash = encoder.Encode(Guid.NewGuid());
            var existingMapping = await repository.GetByUrlHashAsync(urlHash, cancellationToken);
            if (existingMapping != null)
            {
                continue;
            }

            return urlHash;
        }
    }
}