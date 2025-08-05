using MediatR;

namespace UrlShortener.Application.Commands; //CR - toto je o zvyku - ja radsej pouzivam viac vertikalne delenie adresarov. Teda ...Commands.ShortenUrl.ShortUrlCommand (v tej istej zlozke nasledne bude aj handler)

public class ShortenUrlCommand : IRequest<string>
{
    public required string Url { get; set; }
}