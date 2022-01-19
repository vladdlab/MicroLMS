namespace MicroLMS.Domain;

public class Session
{
    public Guid Id { get; set; }
    public SessionType Type { get; set; }
    public string Name { get; set; }
    public int Hours { get; set; }
    public string? Description { get; set; }
    public Guid? ContentLinkId { get; set; }
    public Guid DisciplineId { get; set; }

    public ContentLink? ContentLink { get; set; }
    public Discipline? Discipline { get; set; }
    public ICollection<ExerciseBlock>? ExerciseBlocks { get; set; }
}