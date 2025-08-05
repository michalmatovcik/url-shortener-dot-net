using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Shortening.Domain;

namespace UrlShortener.Api;

[ApiController]
[Route("api")]
public class UrlController(IMediator mediator) : ControllerBase
{
    [HttpPost("shorten")]
    public async Task<IActionResult> ShortenUrl([FromBody] ShortenUrlCommand command)
    {
        var shortUrl = await mediator.Send(command);
        return Ok(new { ShortUrl = shortUrl });
    }
    
    [HttpGet("{urlHash}")]
    public async Task<IActionResult> ResolveUrl(string urlHash)
    {
        var query = new ResolveUrlQuery { UrlHash = urlHash };
        var resolvedUrl = await mediator.Send(query);

        return Redirect(resolvedUrl);
    }
}