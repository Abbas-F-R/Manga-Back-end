namespace MangaA.Model;

public class Chapter : BaseEntity
{
    public int? ChapterNumber { get; set; } 
    public List<string>? ImagesPath { get; set; }
    public Guid? MangaId { get; set; }
    public Manga? Manga { get; set; }
    public List<Comment>? Comments { get; set; }

}