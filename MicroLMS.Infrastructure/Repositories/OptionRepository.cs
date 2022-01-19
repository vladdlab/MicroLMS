using MicroLMS.Domain;
using MicroLMS.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroLMS.Infrastructure.Repositories;

public class OptionRepository : IOptionRepository
{
    private readonly MicroLMSContext _context;

    public OptionRepository(MicroLMSContext context)
    {
        _context = context;
    }

    public async Task<Option> CreateOptionAsync(Option option)
    {
        var res = _context.Options.Add(option);
        await _context.SaveChangesAsync();
        return res.Entity;
    }

    public async Task<bool> DeleteOptionAsync(Guid optionId)
    {
        var option = await _context.Options.FindAsync(optionId);
        if (option == null) return false;
        _context.Options.Remove(option);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Option?> GetOptionAsync(Guid optionId)
    {
        return await _context.Options.FindAsync(optionId);
    }

    public async Task<IList<Option>> GetOptionsAsync()
    {
        return await _context.Options.ToListAsync();
    }

    public async Task<Option> UpdateOptionAsync(Option option)
    {
        var res = _context.Options.Update(option);
        await _context.SaveChangesAsync();
        return res.Entity;
    }

    public async Task<bool> ExistsAsync(Guid optionId)
    {
        return await _context.Options.AnyAsync(p => p.Id == optionId);
    }
}