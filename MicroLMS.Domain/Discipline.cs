namespace MicroLMS.Domain;

public class Discipline
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<Session>? Sessions { get; set; }
}