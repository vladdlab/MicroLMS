namespace MicroLMS.Domain.Interfaces;

public interface IDisciplineRepository
{
    Task<Discipline> CreateDisciplineAsync(Discipline discipline);
    Task<bool> DeleteDisciplineAsync(Guid disciplineId);
    Task<Discipline?> GetDisciplineAsync(Guid disciplineId);
    Task<IList<Discipline>> GetDisciplinesAsync();
    Task<Discipline> UpdateDisciplineAsync(Discipline discipline);
    Task<bool> ExistsAsync(Guid disciplineId);
}