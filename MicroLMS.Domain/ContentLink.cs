namespace MicroLMS.Domain;

public class ContentLink
{
    public Guid Id { get; set; }
    public ContentLinkType Type { get; set; }
    public string Url { get; set; }
}