using MangaA.Dto.Tag;
using MangaA.Service.TagService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace MangaA.Controller;

[Route("api/[controller]")] // Ensure route is correct for TagController
[ApiController]
public class TagController(ITagService service) : BaseController
{

    [HttpPost]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<TagResponse>> Add([FromBody] TagForm form) => Ok(await service.Add(Id, form));
    [HttpGet]
    public async Task<ActionResult<Respons<TagResponse>>> GetAll([FromQuery] TagFilter filter) => Ok(await service.GetAll(filter)); 
  
}