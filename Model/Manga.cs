namespace MangaA.Model;

public class Manga : BaseEntity
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Artist { get; set; }
    public Status? Status { get; set; }
    public DateTime? UpdatingDate { get; set; } = DateTime.UtcNow;
    public long? Views { get; set; } = 0;
    public string? YearOfIssue { get; set; }
    public List<Chapter>? ChaptersList { get; set; }
    public string? CoverImage { get; set; }
    public string? Description { get; set; }
    public List<Tag>? Tags { get; set; }
    public List<Category>? Categories { get; set; }
    public List<Rate>? Rates { get; set; }

    public Guid? UserId { get; set; }
    public User? User { get; set;}
    
}