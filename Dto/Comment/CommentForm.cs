namespace MangaA.Dto.Comment;

public class CommentForm
{
    public required string CommentText { get; set; }
    public required Guid ChapterId { get; set; }
}