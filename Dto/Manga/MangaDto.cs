namespace MangaA.Dto.Manga;

public class MangaDto
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Artist { get; set; }
    public Status? Status { get; set; }
    public string? CoverImage { get; set; }
    public string? Description { get; set; }  
    public List<string>? TagName { get; set; }
    public List<string>? CategoriesName { get; set; }
    public double RateNumber { get; set; }
    public long? Views { get; set; }
    public string? YearOfIssue { get; set; }
}