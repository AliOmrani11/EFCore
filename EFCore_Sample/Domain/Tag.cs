namespace EFCore_Sample.Domain;

public class Tag
{
    public int Id { get; set; }
    public string? Title { get; set; }
    
    
    
    public ICollection<Post> Posts { get; set; } = new List<Post>();
    public List<PostTag> PostTags { get; set; }= new List<PostTag>();
}