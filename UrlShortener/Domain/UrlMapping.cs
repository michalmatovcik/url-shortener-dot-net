namespace UrlShortener.Domain;

public class UrlMapping
{
    public int Id { get; set; }
    public required string OriginalUrl { get; set; }
    public required string ShortenedUrl { get; set; }
}