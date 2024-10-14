using MangaA.Dto.Rate;
using MangaA.Service.RateService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace MangaA.Controller;

[Route("api/[Controller]")]
[ApiController]
public class RateController(IRateService service): BaseController
{
    [HttpPost]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<RateDto>> Add([FromBody] RateForm form) => Ok(await service.Add(Id,form));
  
}