namespace MicroLMS.Domain.Interfaces;

public interface IExerciseVariantRepository
{
    Task<ExerciseVariant> CreateExerciseVariantAsync(ExerciseVariant exerciseVariant);
    Task<bool> DeleteExerciseVariantAsync(Guid exerciseVariantId);
    Task<ExerciseVariant?> GetExerciseVariantAsync(Guid exerciseVariantId);
    Task<IList<ExerciseVariant>> GetExerciseVariantsAsync();
    Task<ExerciseVariant> UpdateExerciseVariantAsync(ExerciseVariant exerciseVariant);
    Task<bool> ExistsAsync(Guid exerciseVariantId);
}