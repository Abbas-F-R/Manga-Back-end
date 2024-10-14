namespace MangaA.Model;

public class CommentImage : BaseEntity
{
    public string Image { get; set; }
    public Guid? CommentId { get; set; }
    public Comment? Comment { get; set; }
}