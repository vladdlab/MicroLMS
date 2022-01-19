namespace MicroLMS.Domain.Interfaces;

public interface IOptionRepository
{
    Task<Option> CreateOptionAsync(Option option);
    Task<bool> DeleteOptionAsync(Guid optionId);
    Task<Option?> GetOptionAsync(Guid optionId);
    Task<IList<Option>> GetOptionsAsync();
    Task<Option> UpdateOptionAsync(Option option);
    Task<bool> ExistsAsync(Guid optionId);
}