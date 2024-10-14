namespace MangaA.Dto.Manga;

public class MangaUpdate 
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string Artist { get; set; }

    public required Status Status { get; set; }
    public required string CoverImage { get; set; }
    public required string Description { get; set; }  
}