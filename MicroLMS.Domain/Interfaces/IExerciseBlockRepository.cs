namespace MicroLMS.Domain.Interfaces;

public interface IExerciseBlockRepository
{
    Task<ExerciseBlock> CreateExerciseBlockAsync(ExerciseBlock exerciseBlock);
    Task<bool> DeleteExerciseBlockAsync(Guid exerciseBlockId);
    Task<ExerciseBlock?> GetExerciseBlockAsync(Guid exerciseBlockId);
    Task<IList<ExerciseBlock>> GetExerciseBlocksAsync();
    Task<ExerciseBlock> UpdateExerciseBlockAsync(ExerciseBlock exerciseBlock);
    Task<bool> ExistsAsync(Guid exerciseBlockId);
}