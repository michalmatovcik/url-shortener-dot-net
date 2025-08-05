using MediatR;
using UrlShortener.Application.Commands;

namespace UrlShortener.Application;

public class ShortenUrlHandler: IRequestHandler<ShortenUrlCommand, string>
{
    public Task<string> Handle(ShortenUrlCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult("");
    }
}