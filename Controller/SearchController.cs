using MangaA.Service.SearchService;
using Microsoft.AspNetCore.Mvc;
namespace MangaA.Controller;

[Route("api/[Controller]")]
[ApiController]
public class SearchController(ISearchService service) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<Respons<SearchResponse>>> Search([FromQuery] SearchFilter filter) => Ok( await service.Search(filter), filter.PageNumber, filter.PageSize);
}