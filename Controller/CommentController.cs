using MangaA.Dto.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace MangaA.Controller;

[Route("api/[Controller]")]
[ApiController]
public class CommentController(ICommentService service) : BaseController
{
    
    [HttpPost]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<CommentDto>> Add([FromBody] CommentForm form) => Ok(await service.Add(Id,form));
    [HttpGet]
    public async Task<ActionResult<Respons<CommentResponse>>> GetAll([FromQuery] CommentFilter filter) => Ok(await service.GetAll(filter), filter.PageNumber, filter.PageSize);
  
    
    [HttpPut("{id}")]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<CommentDto>> Update(Guid id, [FromBody] CommentUpdate update) => Ok(await service.Update(Id, id, update));
    [HttpDelete("{id}")]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<CommentDto>> Delete(Guid id) => Ok(await service.Delete(Id, id));
  
}