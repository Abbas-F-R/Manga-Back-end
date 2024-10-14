
namespace MangaA.Service.ChapterService;

public interface IChapterService
{
    Task<(ChapterDto? data, string? error)> Add(ChapterForm form);
    Task<(ChapterDto? data, string? error)> Get(Guid id);
    Task<(List<ChapterResponse>? data, int? totalCount, string? error)> GetAll(ChapterFilter filter);
    Task<(ChapterDto? data, string? error)> Update(Guid id, ChapterUpdate update);
    Task<(ChapterDto? data, string? error)> Delete(Guid id);
}