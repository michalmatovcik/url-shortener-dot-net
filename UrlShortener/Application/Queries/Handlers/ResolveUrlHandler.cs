using MediatR;
using UrlShortener.Shortening.Domain;

namespace UrlShortener.Application;

public class ResolveUrlHandler(IUrlService urlService) : IRequestHandler<ResolveUrlQuery, string>
{
    public Task<string> Handle(ResolveUrlQuery request, CancellationToken cancellationToken)
    {
        return urlService.GetFullUrlAsync(request.UrlHash, cancellationToken);
    }
}