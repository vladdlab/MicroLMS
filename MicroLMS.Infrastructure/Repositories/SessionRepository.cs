using MicroLMS.Domain;
using MicroLMS.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroLMS.Infrastructure.Repositories;

public class SessionRepository : ISessionRepository
{
    private readonly MicroLMSContext _context;

    public SessionRepository(MicroLMSContext context)
    {
        _context = context;
    }

    public async Task<Session> CreateSessionAsync(Session session)
    {
        var res = _context.Sessions.Add(session);
        await _context.SaveChangesAsync();
        return res.Entity;
    }

    public async Task<bool> DeleteSessionAsync(Guid sessionId)
    {
        var session = await _context.Sessions.FindAsync(sessionId);
        if (session == null) return false;
        _context.Sessions.Remove(session);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Session?> GetSessionAsync(Guid sessionId)
    {
        var session = await _context.Sessions.FindAsync(sessionId);
        if (session == null) return session;
        await _context.Entry(session)
            .Collection(x => x.ExerciseBlocks!)
            .LoadAsync();
        await _context.Entry(session)
            .Reference(x => x.ContentLink)
            .LoadAsync();
        return session;
    }

    public async Task<IList<Session>> GetSessionsAsync()
    {
        return await _context.Sessions.ToListAsync();
    }

    public async Task<Session> UpdateSessionAsync(Session session)
    {
        var res = _context.Sessions.Update(session);
        await _context.SaveChangesAsync();
        return res.Entity;
    }

    public async Task<bool> ExistsAsync(Guid sessionId)
    {
        return await _context.Sessions.AnyAsync(p => p.Id == sessionId);
    }
}