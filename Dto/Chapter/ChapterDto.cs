namespace MangaA.Dto.Chapter;

public class ChapterDto
{
    public int? ChapterNumber { get; set; } 
    public List<string>? ImagesPath { get; set; }
    public Guid? MangaId { get; set; }
    public string? Title { get; set; }
}