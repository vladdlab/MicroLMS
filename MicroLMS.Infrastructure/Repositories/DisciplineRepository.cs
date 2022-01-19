using MicroLMS.Domain;
using MicroLMS.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroLMS.Infrastructure.Repositories;

public class DisciplineRepository : IDisciplineRepository
{
    private readonly MicroLMSContext _context;

    public DisciplineRepository(MicroLMSContext context)
    {
        _context = context;
    }

    public async Task<Discipline> CreateDisciplineAsync(Discipline discipline)
    {
        var res = _context.Disciplines.Add(discipline);
        await _context.SaveChangesAsync();
        return res.Entity;
    }

    public async Task<bool> DeleteDisciplineAsync(Guid disciplineId)
    {
        var discipline = await _context.Disciplines.FindAsync(disciplineId);
        if (discipline == null) return false;
        _context.Disciplines.Remove(discipline);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Discipline?> GetDisciplineAsync(Guid disciplineId)
    {
        var discipline = await _context.Disciplines.FindAsync(disciplineId);
        if (discipline == null) return discipline;
        await _context.Entry(discipline)
            .Collection(x => x.Sessions!)
            .LoadAsync();
        return discipline;
    }

    public async Task<IList<Discipline>> GetDisciplinesAsync()
    {
        return await _context.Disciplines.ToListAsync();
    }

    public async Task<Discipline> UpdateDisciplineAsync(Discipline discipline)
    {
        var res = _context.Disciplines.Update(discipline);
        await _context.SaveChangesAsync();
        return res.Entity;
    }

    public async Task<bool> ExistsAsync(Guid disciplineId)
    {
        return await _context.Disciplines.AnyAsync(p => p.Id == disciplineId);
    }
}