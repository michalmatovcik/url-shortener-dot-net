using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.Commands;
using UrlShortener.Application.Queries;

namespace UrlShortener.Api;

[ApiController]
[Route("api/[controller]")]
public class UrlController : ControllerBase
{
    private readonly IMediator _mediator;

    public UrlController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("shorten")]
    public async Task<IActionResult> ShortenUrl([FromBody] ShortenUrlCommand command)
    {
        if (string.IsNullOrEmpty(command.Url))
        {
            return BadRequest("Original URL cannot be empty.");
        }
        
        var shortUrl = await _mediator.Send(command);
        return Ok(new { ShortUrl = shortUrl });
    }
    
    [HttpGet("resolve")]
    public async Task<IActionResult> ResolveUrl(string shortUrl)
    {
        var query = new ResolveUrlQuery { ShortUrl = shortUrl };
        var resolvedUrl = await _mediator.Send(query);

        return Redirect(resolvedUrl);
    }
}