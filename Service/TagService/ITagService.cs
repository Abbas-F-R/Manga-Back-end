using MangaA.Dto.Tag;
namespace MangaA.Service.TagService;

public interface ITagService
{
    Task<(TagResponse? data, string? error)> Add(Guid userId,TagForm form);
    Task<(List<TagResponse>? data, int? totalCount, string? error)> GetAll(TagFilter filter);
}