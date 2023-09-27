using CRUD_4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

[ApiController]
[Route("[controller]")]
public class LanguageController : ControllerBase
{
    private readonly LanguageRepository _languageRepository;

    public LanguageController(IConfiguration configuration)
    {
        _languageRepository = new LanguageRepository(configuration.GetConnectionString("DefaultConnection"));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_languageRepository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var language = _languageRepository.GetById(id);
        if (language == null)
        {
            return NotFound();
        }
        return Ok(language);
    }

    [HttpPost]
    public IActionResult Create(Language language)
    {
        var createdLanguage = _languageRepository.Insert(language);
        return Ok(createdLanguage);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Language language)
    {
        if (_languageRepository.GetById(id) == null)
        {
            return NotFound();
        }
        language.LanguageId = id;
        _languageRepository.Update(language);
        return Ok(language);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (_languageRepository.GetById(id) == null)
        {
            return NotFound();
        }
        _languageRepository.Delete(id);
        return NoContent();
    }
}