namespace MicroLMS.Domain;

public class Exercise
{
    public Guid Id { get; set; }
    public ExerciseType Type { get; set; }
    public int Number { get; set; }
    public float Complexity { get; set; }
    public Guid ExerciseBlockId { get; set; }
    public Guid? ContentLinkId { get; set; }

    public ContentLink? ContentLink { get; set; }
    public ExerciseBlock? ExerciseBlock { get; set; }
    public Option? Option { get; set; }
    public ICollection<ExerciseVariant>? ExerciseVariants { get; set; }
}