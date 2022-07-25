using System.ComponentModel.DataAnnotations;

namespace EFCore_Sample.Dto.Request;

public class ArticleDto
{
    [Required(ErrorMessage = "Enter Title") , MaxLength(500 , ErrorMessage = "Enter a maximum of 500 characters")]
    public string? Title { get; set; }
    [Required(ErrorMessage = "Enter Slug") , MaxLength(500 , ErrorMessage = "Enter a maximum of 500 characters")]
    public string? Slug { get; set; }
    [Required(ErrorMessage = "Enter Url") , MaxLength(500 , ErrorMessage = "Enter a maximum of 500 characters")]
    public string? Url { get; set; }
    [Required(ErrorMessage = "Enter Content")]
    public string? Content { get; set; }

    public List<int> Tag { get; set; }
}