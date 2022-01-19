using MicroLMS.Domain;
using MicroLMS.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroLMS.Infrastructure.Repositories;

public class ContentLinkRepository : IContentLinkRepository
{
    private readonly MicroLMSContext _context;

    public ContentLinkRepository(MicroLMSContext context)
    {
        _context = context;
    }

    public async Task<ContentLink> CreateContentLinkAsync(ContentLink contentLink)
    {
        var res = _context.ContentLinks.Add(contentLink);
        await _context.SaveChangesAsync();
        return res.Entity;
    }

    public async Task<bool> DeleteContentLinkAsync(Guid contentLinkId)
    {
        var contentLink = await _context.ContentLinks.FindAsync(contentLinkId);
        if (contentLink == null) return false;
        _context.ContentLinks.Remove(contentLink);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<ContentLink?> GetContentLinkAsync(Guid contentLinkId)
    {
        return await _context.ContentLinks.FindAsync(contentLinkId);
    }

    public async Task<IList<ContentLink>> GetContentLinksAsync()
    {
        return await _context.ContentLinks.ToListAsync();
    }

    public async Task<ContentLink> UpdateContentLinkAsync(ContentLink contentLink)
    {
        var res = _context.ContentLinks.Update(contentLink);
        await _context.SaveChangesAsync();
        return res.Entity;
    }

    public async Task<bool> ExistsAsync(Guid contentLinkId)
    {
        return await _context.ContentLinks.AnyAsync(p => p.Id == contentLinkId);
    }
}