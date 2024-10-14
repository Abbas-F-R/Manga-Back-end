namespace MangaA.Service.SearchService;

public interface ISearchService
{
    Task<(List<SearchResponse>? data, int? totalCount, string? error)> Search(SearchFilter request);
}