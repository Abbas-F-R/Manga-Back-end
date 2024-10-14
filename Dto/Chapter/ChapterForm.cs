namespace MangaA.Dto.Chapter;

public class ChapterForm
{
    public int? ChapterNumber { get; set; } 
    public List<string>? ImagesPath { get; set; }
    public Guid MangaId { get; set; }
}