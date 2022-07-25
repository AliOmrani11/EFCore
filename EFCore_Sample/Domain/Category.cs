namespace EFCore_Sample.Domain;

public class Category : Base
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool IsDeleted { get; set; }

    public ICollection<Post> Posts { get; set; } = new List<Post>();
    public List<PostCategory> PostCategories { get; set; }= new List<PostCategory>();
}