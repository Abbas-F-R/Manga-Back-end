namespace MangaA.Dto.Comment;

public class CommentResponse
{
    public Guid? Id { get; set; }
    public string? CommentText { get; set; }
    public int? LikeCount { get; set; } = 0;
    public string? CreationDate { get; set; }
}