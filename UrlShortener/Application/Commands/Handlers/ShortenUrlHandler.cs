using MediatR;
using UrlShortener.Shortening.Domain;

namespace UrlShortener.Application;

public class ShortenUrlHandler(IUrlService urlService) : IRequestHandler<ShortenUrlCommand, string>
{
    public Task<string> Handle(ShortenUrlCommand request, CancellationToken cancellationToken)
    {
        return urlService.ShortenUrlAsync(request.Url, cancellationToken);
    }
}