namespace MangaA.Model;

public class Comment : BaseEntity
{
    public string? CommentText { get; set; }
    public Guid? UserId { get; set; }
    public User? User { get; set; }
    public Guid? ChapterId { get; set; }
    public Chapter? Chapter { get; set; }
    public CommentImage? CommentImage { get; set; }
    public int? LikeCount { get; set; } = 0;
    public List<Like>? Likes { get; set; }

}