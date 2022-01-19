using MicroLMS.Domain;
using MicroLMS.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroLMS.Infrastructure.Repositories;

public class ExerciseRepository : IExerciseRepository
{
    private readonly MicroLMSContext _context;

    public ExerciseRepository(MicroLMSContext context)
    {
        _context = context;
    }

    public async Task<Exercise> CreateExerciseAsync(Exercise exercise)
    {
        var res = _context.Exercises.Add(exercise);
        await _context.SaveChangesAsync();
        return res.Entity;
    }

    public async Task<bool> DeleteExerciseAsync(Guid exerciseId)
    {
        var exercise = await _context.Exercises.FindAsync(exerciseId);
        if (exercise == null) return false;
        _context.Exercises.Remove(exercise);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Exercise?> GetExerciseAsync(Guid exerciseId)
    {
        var exercise = await _context.Exercises.FindAsync(exerciseId);
        if (exercise == null) return exercise;
        await _context.Entry(exercise)
            .Collection(x => x.ExerciseVariants!)
            .LoadAsync();
        await _context.Entry(exercise)
            .Reference(x => x.ContentLink)
            .LoadAsync();
        await _context.Entry(exercise)
            .Reference(x => x.Option)
            .LoadAsync();
        return exercise;
    }

    public async Task<IList<Exercise>> GetExercisesAsync()
    {
        return await _context.Exercises.ToListAsync();
    }

    public async Task<Exercise> UpdateExerciseAsync(Exercise exercise)
    {
        var res = _context.Exercises.Update(exercise);
        await _context.SaveChangesAsync();
        return res.Entity;
    }

    public async Task<bool> ExistsAsync(Guid exerciseId)
    {
        return await _context.Exercises.AnyAsync(p => p.Id == exerciseId);
    }
}