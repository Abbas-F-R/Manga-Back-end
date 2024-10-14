namespace MangaA.Model;

public class Category : BaseEntity
{
    public string? Name { get; set; }
    public List<Manga>? Mangas { get; set; }
}