using MicroLMS.Domain;
using MicroLMS.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroLMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SessionController : ControllerBase
{
    private readonly ISessionRepository _sessionRepository;

    public SessionController(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IList<Session>>> IndexSession()
    {
        return Ok(await _sessionRepository.GetSessionsAsync());
    }

    [HttpGet("{sessionId:guid}")]
    public async Task<ActionResult<Session>> GetSession(Guid sessionId)
    {
        var session = await _sessionRepository.GetSessionAsync(sessionId);
        if (session == null)
        {
            return NotFound();
        }

        return Ok(session);
    }

    [HttpPost]
    public async Task<ActionResult<Session>> CreateSession(Session session)
    {
        var createdSession = await _sessionRepository.CreateSessionAsync(session);
        return Created(nameof(session), createdSession);
    }

    [HttpPut("{sessionId:guid}")]
    public async Task<ActionResult<Session>> UpdateSession(Guid sessionId, Session session)
    {
        if (sessionId != session.Id)
        {
            return BadRequest();
        }

        if (!await _sessionRepository.ExistsAsync(sessionId))
        {
            return NotFound();
        }

        var updatedSession = await _sessionRepository.UpdateSessionAsync(session);
        return Ok(updatedSession);
    }

    [HttpDelete("{sessionId:guid}")]
    public async Task<IActionResult> DeleteSession(Guid sessionId)
    {
        await _sessionRepository.DeleteSessionAsync(sessionId);
        return Ok();
    }
}