namespace EFCore_Sample.Domain;

public class PostCategory
{
    public DateTime InsertedDate { get; set; }
    
    public int CategoryId { get; set; }
    public int PostId { get; set; }

    public Post? Post { get; set; }
    public Category? Category { get; set; }
}