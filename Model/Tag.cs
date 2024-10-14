namespace MangaA.Model;

public class Tag : BaseEntity
{
    public string? Name { get; set; }
    public List<Manga>? Mangas { get; set; }
}