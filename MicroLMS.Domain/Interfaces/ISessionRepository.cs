namespace MicroLMS.Domain.Interfaces;

public interface ISessionRepository
{
    Task<Session> CreateSessionAsync(Session session);
    Task<bool> DeleteSessionAsync(Guid sessionId);
    Task<Session?> GetSessionAsync(Guid sessionId);
    Task<IList<Session>> GetSessionsAsync();
    Task<Session> UpdateSessionAsync(Session session);
    Task<bool> ExistsAsync(Guid sessionId);
}