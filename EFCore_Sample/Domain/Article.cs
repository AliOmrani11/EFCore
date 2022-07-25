using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Sample.Domain;

public class Article : Post
{
    public string? Content { get; set; }
}