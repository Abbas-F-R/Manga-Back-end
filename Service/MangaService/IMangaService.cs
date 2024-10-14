using MangaA.Dto.Manga;
namespace MangaA.Service.MangaService;

public interface IMangaService
{
    Task<(MangaDto? data, string? error)> GetById (Guid id);
    Task<(List<MangaResponse>? data , int? totalCount, string? error)> GetAll(MangaFilter filter);
    Task<(MangaDto? data, string? error)> Add(Guid id,MangaForm form);
    Task<(MangaDto? data, string? error)> Update(Guid id, MangaUpdate update);
    Task<(MangaDto? data, string? error)> Delete(Guid id);
    Task<(MangaDto? data, string? error)> AddCategoriesToManga(Guid mangaId, List<Guid> categoryIds);
    Task<(MangaDto? data, string? error)> AddTagsToManga(Guid mangaId, List<Guid> tagIds);
    
    
}