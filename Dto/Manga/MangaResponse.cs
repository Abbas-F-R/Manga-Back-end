namespace MangaA.Dto.Manga;

public class MangaResponse
{
    public Guid? Id { get; set; }
    public string? Title { get; set; }
    public string? CoverImage { get; set; }
    public List<string>? CreationDate { get; set; }
    public List<int>? ChapterNumber { get; set; } 
    public List<Guid>? ChapterId { get; set; } 
    public double RateNumber { get; set; }

}