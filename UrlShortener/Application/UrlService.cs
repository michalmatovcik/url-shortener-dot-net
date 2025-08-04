namespace UrlShortener.Application;

public class UrlService : IUrlService
{
    private readonly ICacheService _cacheService;
    private readonly IUrlRepository _urlRepository;

    public UrlService(ICacheService cacheService, IUrlRepository urlRepository)
    {
        _cacheService = cacheService;
        _urlRepository = urlRepository;
    }

    public async Task<string> ShortenUrlAsync(string original_url)
    {
        return await Task.FromResult("");
    }

    public async Task<string> GetOriginalUrlAsync(string shortUrl)
    {
        return await Task.FromResult("");
    }
}