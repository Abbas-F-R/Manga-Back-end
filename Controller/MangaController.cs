using MangaA.Service.MangaService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace MangaA.Controller;

[Route("api/[Controller]")]
[ApiController]
public class MangaController(IMangaService mangaService) : BaseController
{
 

    [HttpPost]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<MangaDto>> Add([FromBody] MangaForm form) => Ok(await mangaService.Add(Id,form));
    [HttpGet("{id}")]
    public async Task<ActionResult<MangaDto>> Get(Guid id) => Ok(await mangaService.GetById(id));
    [HttpGet]
    public async Task<ActionResult<Respons<MangaResponse>>> GetAll([FromQuery] MangaFilter filter) =>
        Ok(await mangaService.GetAll(filter), filter.PageNumber, filter.PageSize);
    [HttpPut("{id}")]
    public async Task<ActionResult<MangaDto>> Update(Guid id, [FromBody] MangaUpdate update) => Ok(await mangaService.Update(id, update));
    [HttpDelete("{id}")]
    public async Task<ActionResult<MangaDto>> Delete(Guid id) => Ok(await mangaService.Delete(id));
    [HttpPost ("AddCategoriesToManga/{id}")]
    public async Task<ActionResult<MangaDto>> AddCategories( Guid id, [FromBody] List<Guid> categoryIds) => Ok(await mangaService.AddCategoriesToManga(id, categoryIds));
    
    [HttpPost ("AddTagsToManga(/{id}")]
    public async Task<ActionResult<MangaDto>> AddTags( Guid id, [FromBody] List<Guid> tagsIds) => Ok(await mangaService.AddTagsToManga(id, tagsIds));


   
}