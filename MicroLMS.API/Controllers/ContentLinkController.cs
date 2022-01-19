using MicroLMS.Domain;
using MicroLMS.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroLMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContentLinkController : ControllerBase
{
    private readonly IContentLinkRepository _contentLinkRepository;

    public ContentLinkController(IContentLinkRepository contentLinkRepository)
    {
        _contentLinkRepository = contentLinkRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IList<ContentLink>>> IndexContentLink()
    {
        return Ok(await _contentLinkRepository.GetContentLinksAsync());
    }

    [HttpGet("{contentLinkId:guid}")]
    public async Task<ActionResult<ContentLink>> GetContentLink(Guid contentLinkId)
    {
        var contentLink = await _contentLinkRepository.GetContentLinkAsync(contentLinkId);
        if (contentLink == null)
        {
            return NotFound();
        }

        return Ok(contentLink);
    }

    [HttpPost]
    public async Task<ActionResult<ContentLink>> CreateContentLink(ContentLink contentLink)
    {
        var createdContentLink = await _contentLinkRepository.CreateContentLinkAsync(contentLink);
        return Created(nameof(contentLink), createdContentLink);
    }

    [HttpPut("{contentLinkId:guid}")]
    public async Task<ActionResult<ContentLink>> UpdateContentLink(Guid contentLinkId, ContentLink contentLink)
    {
        if (contentLinkId != contentLink.Id)
        {
            return BadRequest();
        }

        if (!await _contentLinkRepository.ExistsAsync(contentLinkId))
        {
            return NotFound();
        }

        var updatedContentLink = await _contentLinkRepository.UpdateContentLinkAsync(contentLink);
        return Ok(updatedContentLink);
    }

    [HttpDelete("{contentLinkId:guid}")]
    public async Task<IActionResult> DeleteContentLink(Guid contentLinkId)
    {
        await _contentLinkRepository.DeleteContentLinkAsync(contentLinkId);
        return Ok();
    }
}