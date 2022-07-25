using System.ComponentModel.DataAnnotations;

namespace EFCore_Sample.Dto.Request;

public class TagDto
{
    [Required(ErrorMessage = "Enter Title") , MaxLength(ErrorMessage = "Enter a maximum of 250 characters")]
    public string? Title { get; set; }
}