using MangaA.Service.ChapterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace MangaA.Controller;

[Route("api/[Controller]")]
[ApiController]
public class ChapterController(IChapterService chapterService) : BaseController
{
    [HttpPost]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<ChapterDto>> Add([FromBody] ChapterForm form) => Ok(await chapterService.Add(form));
    [HttpGet("{id}")]
    public async Task<ActionResult<ChapterDto>> Get(Guid id) => 
        Ok(await chapterService.Get(id));
    [HttpGet]
    public async Task<ActionResult<Respons<ChapterResponse>>> GetAll([FromQuery] ChapterFilter filter) =>
        Ok(await chapterService.GetAll(filter), filter.PageNumber, filter.PageSize);

    [HttpPut("{id}")]
    public async Task<ActionResult<ChapterDto>> Update(Guid id, [FromBody] ChapterUpdate update) => 
        Ok(await chapterService.Update(id, update));

    [HttpDelete("{id}")]
    public async Task<ActionResult<ChapterDto>> Delete(Guid id) => 
        Ok(await chapterService.Delete(id));
}