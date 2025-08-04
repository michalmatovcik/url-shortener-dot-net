using MediatR;

namespace UrlShortener.Shortening.Domain;

public class ShortenUrlCommand : IRequest<string>
{
    public required string Url { get; set; }
}