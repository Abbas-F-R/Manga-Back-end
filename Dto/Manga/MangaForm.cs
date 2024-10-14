namespace MangaA.Dto.Manga;

public class MangaForm
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string Artist { get; set; }
    public required Status Status { get; set; }
    public required string CoverImage { get; set; }
    public required string Description { get; set; }  
    public required string YearOfIssue { get; set; }


    
}