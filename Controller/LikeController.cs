using MangaA.Service.LikeService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace MangaA.Controller;
[ApiController]
[Route("api/[Controller]")]
public class LikeController(ILikeService service) : BaseController
{
    [HttpPost ("{commentId}")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> Add(Guid commentId) => Ok(await service.LikeUnlikeComment(Id, commentId));
    // [HttpDelete("{commentId}")]
    // [Authorize(Roles = "User")]
    // public async Task<IActionResult> Delete( Guid commentId) => Ok(await service.Delete(Id,commentId));
}