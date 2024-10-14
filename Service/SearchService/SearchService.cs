using Microsoft.EntityFrameworkCore;
namespace MangaA.Service.SearchService;

public class SearchService(IRepositoryWrapper wrapper, IMapper mapper) : ISearchService
{
    public async Task<(List<SearchResponse>? data, int? totalCount, string? error)> Search(SearchFilter filter)
    {
        if (string.IsNullOrEmpty(filter.Title))
        {
            return (null, null, "Title is required for search");
        }
       var (data, totalCount) = await wrapper.Manga.GetAll(m => 
               string.IsNullOrEmpty(filter.Title) || 
               EF.Functions.Like(m.Title, $"%{filter.Title}%"),
           m => m.Include((x) => x.Rates)!,
           filter.PageNumber,
           filter.PageSize);

        return data != null 
            ? (mapper.Map<List<SearchResponse>>(data) ,totalCount,  null) 
            : (null ,null,  "No data found");
    }
}