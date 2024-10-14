using MangaA.Base;
namespace MangaA.Dto.Manga;

public class MangaFilter : BaseFilter
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Artist { get; set; }
    public Status? Status { get; set; }
    public Guid? CategoryId { get; set; }
    public bool? OrderByViews { get; set; }
    public bool? OrderByUpdatingDate { get; set; }
    public Guid? UserId { get; set; }
    public string? YearOfIssue { get; set; }

}