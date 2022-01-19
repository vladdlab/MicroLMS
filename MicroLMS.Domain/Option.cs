namespace MicroLMS.Domain;

public class Option
{
    public Guid Id { get; set; }
    public OptionType Type { get; set; }
    public OptionUploadType UploadType { get; set; }
    public string? Description { get; set; }
    public Guid ExerciseId { get; set; }
    
    public Exercise? Exercise { get; set; }
}