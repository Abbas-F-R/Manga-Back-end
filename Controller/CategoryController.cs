using MangaA.Dto.Category;
using MangaA.Service.CategoryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace MangaA.Controller;

[Route("api/[Controller]")]
[ApiController]
public class CategoryController(ICategoryService service) : BaseController
{
    [HttpPost]
    [Authorize(Roles = "User")]
    public async Task<ActionResult<CategoryResponse>> Add([FromBody] CategoryForm form) => Ok(await service.Add(Id, form));
    
    [HttpGet]
    public async Task<ActionResult<Respons<CategoryResponse>>> GetAll([FromQuery] CategoryFilter filter) =>
        Ok(await service.GetAll(filter), filter.PageNumber, filter.PageSize);
    
}