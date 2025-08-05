using MediatR;

namespace UrlShortener.Application.Queries; //CR - Rovnaky koment ako v ShortenUrlCommand.cs

public class ResolveUrlQuery: IRequest<string>
{
    public required string ShortUrl { get; set; }
}