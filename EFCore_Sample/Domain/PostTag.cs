namespace EFCore_Sample.Domain;

public class PostTag
{
    public int TagId { get; set; }
    public int PostId { get; set; }

    public Post? Post { get; set; }
    public Tag? Tag { get; set; }
}