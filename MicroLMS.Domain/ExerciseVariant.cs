namespace MicroLMS.Domain;

public class ExerciseVariant
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public float Complexity { get; set; }
    public Guid? ContentLinkId { get; set; }
    public Guid ExerciseId { get; set; }

    public ContentLink? ContentLink { get; set; }
    public Exercise? Exercise { get; set; }
}