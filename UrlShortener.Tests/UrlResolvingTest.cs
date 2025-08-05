using Moq;
using UrlShortener.Application;
using UrlShortener.Domain;
using UrlShortener.Shortening.Domain;

namespace UrlShortener.Tests;

public class UrlResolvingTest
{
    private readonly Mock<IUrlRepository> _mockRepo = new();
    private readonly Mock<IUrlCacheService> _mockCache = new();
    
    private readonly IBase62Encoder _encoder = new Base62Encoder();
    private readonly IUrlService _urlService;

    public UrlResolvingTest()
    {
        _urlService = new UrlService(_mockCache.Object, _mockRepo.Object, _encoder);
    }
    

    [Fact]
    public async Task ShouldResolveShortenedUrl()
    {
        // Given a shortened URL hash
        const string urlHash = "abc123";
        const string originalUrl = "https://www.example.com/some/long/path";
        
        _mockRepo.Setup(repo => repo.GetByUrlHashAsync(urlHash, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new UrlMapping { UrlHash = urlHash, Url = originalUrl });
        
        
        // When the URL is resolved
        var query = new ResolveUrlQuery { UrlHash = urlHash };
        var handler = new ResolveUrlHandler(_urlService);
        var resolvedUrl = await handler.Handle(query, CancellationToken.None);  
        
        // Then the original URL should be returned
        Assert.Equal(originalUrl, resolvedUrl);
        
    }

    [Fact]
    public async Task ShouldThrowExceptionForUnknownShortenedUrl()
    {
        // Given an invalid URL hash
        const string invalidUrlHash = "invalid123";
        
        _mockRepo.Setup(repo => repo.GetByUrlHashAsync(invalidUrlHash, It.IsAny<CancellationToken>()))
            .ReturnsAsync((UrlMapping?)null);
        
        // When the URL is resolved
        var query = new ResolveUrlQuery { UrlHash = invalidUrlHash };
        var handler = new ResolveUrlHandler(_urlService);
        await Assert.ThrowsAsync<KeyNotFoundException>(() => handler.Handle(query, CancellationToken.None));
    }
}