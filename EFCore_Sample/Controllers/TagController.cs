using EFCore_Sample.Domain;
using EFCore_Sample.Dto.Request;
using EFCore_Sample.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_Sample.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TagController : Controller
{
    
    private readonly IRepository<Tag> _repository;

    public TagController(IRepository<Tag> repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> Insert(TagDto entry)
    {
        Tag tag = new Tag()
        {
            Title = entry.Title
        };

        await _repository.Insert(tag);
        await _repository.Save();
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repository.GetAll());
    }
}