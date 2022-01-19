namespace MicroLMS.Domain.Interfaces;

public interface IExerciseRepository
{
    Task<Exercise> CreateExerciseAsync(Exercise exercise);
    Task<bool> DeleteExerciseAsync(Guid exerciseId);
    Task<Exercise?> GetExerciseAsync(Guid exerciseId);
    Task<IList<Exercise>> GetExercisesAsync();
    Task<Exercise> UpdateExerciseAsync(Exercise exercise);
    Task<bool> ExistsAsync(Guid exerciseId);
}