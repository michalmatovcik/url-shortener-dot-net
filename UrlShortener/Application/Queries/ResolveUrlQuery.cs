using MediatR;

namespace UrlShortener.Shortening.Domain;

public class ResolveUrlQuery: IRequest<string>
{
    public required string ShortUrl { get; set; }
}