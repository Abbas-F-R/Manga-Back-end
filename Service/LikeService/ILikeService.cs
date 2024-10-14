namespace MangaA.Service.LikeService;

public interface ILikeService
{
    // Task<(LikeDto? date, string? error)> GetAll(LikeFilter filter);
    // Task<(LikeDto? data, string? error)> Delete(Guid userId, Guid commentId);
    Task<(LikeDto? date, string? error)> LikeUnlikeComment(Guid userId, Guid commentId);
}