using EFCore_Sample.Domain;
using EFCore_Sample.Dto.Request;
using EFCore_Sample.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_Sample.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ArticleController : Controller
{
    private readonly IRepository<Article> _repository;
    private readonly IRepository<Tag> _tagRepository;

    public ArticleController(IRepository<Article> repository, IRepository<Tag> tagRepository)
    {
        _repository = repository;
        _tagRepository = tagRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Insert(ArticleDto entry)
    {
        List<Tag> tags = new List<Tag>();
        foreach (var var in entry.Tag)
        {
            var tag = await _tagRepository.Get(var);
            if (tag != null)
                tags.Add(tag);
        }

        Article article = new Article()
        {
            Content = entry.Content,
            Slug = entry.Slug,
            Title = entry.Title,
            Url = entry.Url,
            Tags = tags
        };
        await _repository.Insert(article);
        await _repository.Save();
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repository.GetAll());
    }
}