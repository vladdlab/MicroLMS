using MicroLMS.Domain;
using MicroLMS.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroLMS.Infrastructure.Repositories;

public class ExerciseBlockRepository : IExerciseBlockRepository
{
    private readonly MicroLMSContext _context;

    public ExerciseBlockRepository(MicroLMSContext context)
    {
        _context = context;
    }

    public async Task<ExerciseBlock> CreateExerciseBlockAsync(ExerciseBlock exerciseBlock)
    {
        var res = _context.ExerciseBlocks.Add(exerciseBlock);
        await _context.SaveChangesAsync();
        return res.Entity;
    }

    public async Task<bool> DeleteExerciseBlockAsync(Guid exerciseBlockId)
    {
        var exerciseBlock = await _context.ExerciseBlocks.FindAsync(exerciseBlockId);
        if (exerciseBlock == null) return false;
        _context.ExerciseBlocks.Remove(exerciseBlock);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<ExerciseBlock?> GetExerciseBlockAsync(Guid exerciseBlockId)
    {
        var exerciseBlock = await _context.ExerciseBlocks.FindAsync(exerciseBlockId);
        if (exerciseBlock == null) return exerciseBlock;
        await _context.Entry(exerciseBlock)
            .Collection(x => x.Exercises!)
            .LoadAsync();
        await _context.Entry(exerciseBlock)
            .Reference(x => x.ContentLink)
            .LoadAsync();
        return exerciseBlock;
    }

    public async Task<IList<ExerciseBlock>> GetExerciseBlocksAsync()
    {
        return await _context.ExerciseBlocks.ToListAsync();
    }

    public async Task<ExerciseBlock> UpdateExerciseBlockAsync(ExerciseBlock exerciseBlock)
    {
        var res = _context.ExerciseBlocks.Update(exerciseBlock);
        await _context.SaveChangesAsync();
        return res.Entity;
    }

    public async Task<bool> ExistsAsync(Guid exerciseBlockId)
    {
        return await _context.ExerciseBlocks.AnyAsync(p => p.Id == exerciseBlockId);
    }
}