namespace MangaA.Dto.Search;

public class SearchResponse
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? CoverImage { get; set; }
    public double RateNumber { get; set; }

}