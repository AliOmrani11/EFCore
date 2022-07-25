namespace EFCore_Sample.Domain;

public class Post 
{
    public int PostId { get; set; }
    public DateTime InsertedDate { get; set; }
    public string? Title { get; set; }
    public bool IsDeleted { get; set; }
    public string? Slug { get; set; }
    public string? Url { get; set; }
    
    public ICollection<Category>? Categories { get; set; }
    public List<PostCategory>? PostCategories { get; set; } = new List<PostCategory>();
    
    
    public ICollection<Tag>? Tags { get; set; }
    public List<PostTag>? PostTags { get; set; }
}