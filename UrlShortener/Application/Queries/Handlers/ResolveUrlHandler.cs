using MediatR;
using UrlShortener.Application.Queries;

namespace UrlShortener.Application;

public class ResolveUrlHandler: IRequestHandler<ResolveUrlQuery, string>
{
    public Task<string> Handle(ResolveUrlQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult("");
    }
}