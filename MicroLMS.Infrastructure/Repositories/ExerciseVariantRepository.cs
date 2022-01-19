using MicroLMS.Domain;
using MicroLMS.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroLMS.Infrastructure.Repositories;

public class ExerciseVariantRepository : IExerciseVariantRepository
{
    private readonly MicroLMSContext _context;

    public ExerciseVariantRepository(MicroLMSContext context)
    {
        _context = context;
    }

    public async Task<ExerciseVariant> CreateExerciseVariantAsync(ExerciseVariant exerciseVariant)
    {
        var res = _context.ExerciseVariants.Add(exerciseVariant);
        await _context.SaveChangesAsync();
        return res.Entity;
    }

    public async Task<bool> DeleteExerciseVariantAsync(Guid exerciseVariantId)
    {
        var exerciseVariant = await _context.ExerciseVariants.FindAsync(exerciseVariantId);
        if (exerciseVariant == null) return false;
        _context.ExerciseVariants.Remove(exerciseVariant);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<ExerciseVariant?> GetExerciseVariantAsync(Guid exerciseVariantId)
    {
        return await _context.ExerciseVariants.FindAsync(exerciseVariantId);
    }

    public async Task<IList<ExerciseVariant>> GetExerciseVariantsAsync()
    {
        return await _context.ExerciseVariants.ToListAsync();
    }

    public async Task<ExerciseVariant> UpdateExerciseVariantAsync(ExerciseVariant exerciseVariant)
    {
        var res = _context.ExerciseVariants.Update(exerciseVariant);
        await _context.SaveChangesAsync();
        return res.Entity;
    }

    public async Task<bool> ExistsAsync(Guid exerciseVariantId)
    {
        return await _context.ExerciseVariants.AnyAsync(p => p.Id == exerciseVariantId);
    }
}