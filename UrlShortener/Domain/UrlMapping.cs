using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Domain;

public class UrlMapping
{
    public int Id { get; set; }
    
    [MaxLength(5000)]
    public required string Url { get; set; }
    
    [MaxLength(20)]
    public required string UrlHash { get; set; }
}