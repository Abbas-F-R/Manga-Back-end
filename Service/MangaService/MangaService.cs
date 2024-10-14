using Microsoft.EntityFrameworkCore;
namespace MangaA.Service.MangaService;

public class MangaService(IRepositoryWrapper wrapper, IMapper mapper) : IMangaService
{

    public async Task<(MangaDto? data, string? error)> GetById(Guid id)
    {
        var manga = await wrapper.Manga.Get(m => m.Id == id,  q => 
            q.Include(m => m.Categories)
                .Include(m => m.Tags)
                .Include(m => m.Rates)!);
        if (manga == null)
        {
            return (null, "Manga not found");
        }

        manga.Views = manga.Views + 1;
        var result = mapper.Map<MangaDto>(manga);

        return (result, null);
    }
    public async Task<(List<MangaResponse>? data, int? totalCount, string? error)> GetAll(MangaFilter filter)
    {
        var (data, totalCount) = await wrapper.Manga.GetAll(m =>
                (string.IsNullOrEmpty(filter.Title) || m.Title!.ToLower().Contains(filter.Title.ToLower())) &&
                (string.IsNullOrEmpty(filter.Artist) || m.Artist == filter.Artist) &&
                (string.IsNullOrEmpty(filter.Author) || m.Author == filter.Author) && 
                (string.IsNullOrEmpty(filter.YearOfIssue) || m.YearOfIssue == filter.YearOfIssue) &&
                (!filter.CategoryId.HasValue || m.Categories!.Any(c => c.Id == filter.CategoryId.Value)) &&
                (!filter.Status.HasValue || m.Status == filter.Status) &&
            (!filter.UserId.HasValue || m.UserId == filter.UserId),
            x => x.Include(m => m.ChaptersList)
                .Include(m => m.Rates)!, filter.PageNumber, filter.PageSize, filter.OrderByViews, filter.OrderByUpdatingDate);
   
        if (data == null || totalCount == 0)
        {
            return (null, 0, "No manga found");
        }
        return ( mapper.Map<List<MangaResponse>>(data), totalCount, null);
    }
    
 

    public async Task<(MangaDto? data, string? error)> Add(Guid userId,MangaForm form)
    {
        var user = await wrapper.User.GetById(userId);
        if (user == null)
        {
            return (null, "User not found to create manga");
        }
        var manga = mapper.Map<Manga>(form);
        manga.UserId = userId;
        var createdManga = await wrapper.Manga.Add(manga);
        return createdManga != null ? (mapper.Map<MangaDto>(createdManga), null) : (null , " creating failed");
    }
    public async Task<(MangaDto? data, string? error)> Update(Guid id, MangaUpdate update)
    {
        var data = await wrapper.Manga.GetById(id);
        if (data == null)
        {
            return (null, "Manga not found");
        }

        if (string.IsNullOrWhiteSpace(update.Author) ||
            string.IsNullOrWhiteSpace(update.Title) ||
            update.Status == null ||
            string.IsNullOrWhiteSpace(update.Description) ||
            string.IsNullOrWhiteSpace(update.CoverImage))
        {
            return (null, "Cannot update manga. Some required fields are missing.");
        }

        mapper.Map(update, data);
        await wrapper.Manga.Update(data);

        return (mapper.Map<MangaDto>(data), null);
    }

    public async Task<(MangaDto? data, string? error)> Delete(Guid id)
    {
        var result = await wrapper.Manga.SoftDelete(id);
        return result == null ?  (null, "Manga not found") :(mapper.Map<MangaDto>(result), null);
    }

    public async Task<(MangaDto? data, string? error)> AddCategoriesToManga(Guid id, List<Guid> categoryIds)
    {
        var manga = await wrapper.Manga.Get(m => m.Id == id, x => x.Include(c => c.Categories)!);
        if (manga != null)
        {
            foreach (var categoryId in categoryIds)
            {
                var data = await wrapper.Category.GetById(categoryId);
                if ( data != null && !manga.Categories.Contains(data))
                {
                    manga.Categories.Add(data);
                }
            }
            await wrapper.Manga.Update(manga);
            return (mapper.Map<MangaDto>(manga) , null);
        }
        return (null, "No manga found to add categories to");
    }

    public async Task<(MangaDto? data, string? error)> AddTagsToManga(Guid mangaId, List<Guid> tagIds)
    {
        // Fetch the manga along with its tags
        var manga = await wrapper.Manga.Get(m => m.Id == mangaId, x => x.Include(t => t.Tags)!);
        if (manga != null)
        {
            foreach (var tagId in tagIds)
            {
                var tag = await wrapper.Tag.GetById(tagId);
                if (tag != null && !manga.Tags.Contains(tag))
                {
                    manga.Tags.Add(tag);
                }
            }

            // Update the manga with new tags
            await wrapper.Manga.Update(manga);
            return (mapper.Map<MangaDto>(manga), null);
        }
        return (null, "No manga found to add tags to");
    }
}