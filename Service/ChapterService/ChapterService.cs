namespace MangaA.Service.ChapterService;

public class ChapterService(IRepositoryWrapper wrapper, IMapper mapper) : IChapterService
{
    
    public async Task<(ChapterDto? data, string? error)> Add( ChapterForm form)
    {
        var chapter = mapper.Map<Chapter>(form);
        var manga = await wrapper.Manga.GetById(form.MangaId);
        if (manga == null)
            return (null, " Manga not found.");
        manga.UpdatingDate = DateTime.UtcNow;
        var data = await wrapper.Chapter.Add(chapter);
        return data != null ? (mapper.Map<ChapterDto>(data), null) : (null, "Failed to add chapter.");
    }
    public async Task<(ChapterDto? data, string? error)> Get(Guid id)
    {
        var chapter = await wrapper.Chapter.GetById(id);
        if (chapter == null)
        {
            return (null, "Chapter not found.");
        }
        return (mapper.Map<ChapterDto>(chapter), null);
    }
    public async Task<(List<ChapterResponse>? data, int? totalCount, string? error)> GetAll(ChapterFilter filter)
    {
        var (data, totalCount) = await wrapper.Chapter.GetAll<ChapterResponse>(c =>
            (!filter.MangaId.HasValue) || (c.MangaId == filter.MangaId));

        return (data == null || data.Count == 0 || totalCount == 0)
            ? (null, 0, "No chapters found.")
            : (data, totalCount, null);
    }
    public async Task<(ChapterDto? data, string? error)> Update(Guid id, ChapterUpdate update)
    {
        var chapter = await wrapper.Chapter.GetById(id);
        if (chapter == null)
        {
            return (null, "Chapter not found.");
        }
        mapper.Map(update, chapter); 
        var data = await wrapper.Chapter.Update(chapter);
        return (mapper.Map<ChapterDto>(data), null);
    }

    public async Task<(ChapterDto? data, string? error)> Delete(Guid id)
    {
        var result = await wrapper.Chapter.SoftDelete(id);
        return result == null 
            ? (null, "Manga not found") 
            :(mapper.Map<ChapterDto>(result), null);
    }



}