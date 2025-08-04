using MediatR;
using UrlShortener.Shortening.Domain;

namespace UrlShortener.Application;

public class ShortenUrlHandler: IRequestHandler<ShortenUrlCommand, string>
{
    public Task<string> Handle(ShortenUrlCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult("");
    }
}