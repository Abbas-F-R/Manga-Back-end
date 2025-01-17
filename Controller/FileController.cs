using MangaA.Service.FileService;
using Microsoft.AspNetCore.Mvc;
namespace MangaA.Controller;

[ApiController]
[Route("api/[Controller]")]
public class FileController(IFileService fileService) : BaseController
{
    [HttpPost("Upload")]
    public async Task<IActionResult> Upload([FromForm] IFormFile[] files) => Ok(await fileService.Upload(files));
    // [HttpGet("Download/{filename}")]
    // public async Task<IActionResult> Download(string filename) => OkFile(await fileService.DownloadFile(filename));

}