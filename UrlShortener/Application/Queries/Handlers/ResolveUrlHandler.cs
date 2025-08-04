using MediatR;
using UrlShortener.Shortening.Domain;

namespace UrlShortener.Application;

public class ResolveUrlHandler: IRequestHandler<ResolveUrlQuery, string>
{
    public Task<string> Handle(ResolveUrlQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult("");
    }
}