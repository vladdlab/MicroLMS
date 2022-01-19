namespace MicroLMS.Domain.Interfaces;

public interface IContentLinkRepository
{
    Task<ContentLink> CreateContentLinkAsync(ContentLink contentLink);
    Task<bool> DeleteContentLinkAsync(Guid contentLinkId);
    Task<ContentLink?> GetContentLinkAsync(Guid contentLinkId);
    Task<IList<ContentLink>> GetContentLinksAsync();
    Task<ContentLink> UpdateContentLinkAsync(ContentLink contentLink);
    Task<bool> ExistsAsync(Guid contentLinkId);
}