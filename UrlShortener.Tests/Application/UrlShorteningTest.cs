using UrlShortener.Application;
using UrlShortener.Application.Commands;

namespace UrlShortener.Tests.Application;

public class UrlShorteningTest
{
    [Fact]
    public async Task ShouldReturnShortenedUrl()
    {
        // Given a valid original URL
        const string longUrl = "https://www.example.com/some/long/path";
        
        // When the URL is shortened
        var command = new ShortenUrlCommand { Url = longUrl };
        var handler = new ShortenUrlHandler();
        var shortenedUrl = await handler.Handle(command, CancellationToken.None);
        
        // Then the shortened URL should be returned
        Assert.NotNull(shortenedUrl);
        Assert.StartsWith("https://short.url/", shortenedUrl);
        Assert.DoesNotContain(longUrl, shortenedUrl);
        
        
    }
}