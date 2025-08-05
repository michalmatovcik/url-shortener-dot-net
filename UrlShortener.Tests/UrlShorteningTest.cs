using Moq;
using UrlShortener.Application;
using UrlShortener.Domain;
using UrlShortener.Shortening.Domain;

namespace UrlShortener.Tests;

public class UrlShorteningTest
{
    private readonly Mock<IUrlRepository> _mockRepo = new();
    private readonly Mock<IUrlCacheService> _mockCache = new();
    
    private readonly IBase62Encoder _encoder = new Base62Encoder();
    private readonly IUrlService _urlService;

    public UrlShorteningTest()
    {
        _urlService = new UrlService(_mockCache.Object, _mockRepo.Object, _encoder);
    }
    
    
    [Fact]
    public async Task ShouldReturnShortenedUrl()
    {
        // Given a valid original URL
        const string longUrl = "https://www.example.com/some/long/path";
        
        // When the URL is shortened
        var command = new ShortenUrlCommand { Url = longUrl };
        var handler = new ShortenUrlHandler(_urlService);
        var shortenedUrl = await handler.Handle(command, CancellationToken.None);
        
        // Then the shortened URL should be returned
        Assert.NotEmpty(shortenedUrl);
        Assert.DoesNotContain(longUrl, shortenedUrl);
    }
    
}