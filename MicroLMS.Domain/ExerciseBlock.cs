namespace MicroLMS.Domain;

public class ExerciseBlock
{
    public Guid Id { get; set; }
    public ExerciseBlockType Type { get; set; }
    public ExerciseBlockSubtype Subtype { get; set; }
    public string? Guidance { get; set; }
    public string? Description { get; set; }
    public Guid SessionId { get; set; }
    public Guid? ContentLinkId { get; set; }

    public Session? Session { get; set; }
    public ContentLink? ContentLink { get; set; }
    public ICollection<Exercise>? Exercises { get; set; }
}