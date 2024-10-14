namespace MangaA.Service.LikeService;

public class LikeService(IRepositoryWrapper wrapper, IMapper mapper) : ILikeService
{
    public async Task<(LikeDto? date, string? error)> LikeUnlikeComment(Guid userId, Guid commentId)
    {
        var comment = await wrapper.Comment.GetById(commentId);
        if (comment == null)
            return (null, "Comment not found");

        var user = await wrapper.User.GetById(userId);
        if (user == null)
            return (null, "User not found");
        var like = await wrapper.Like.Get((l => l.CommentId == commentId && l.UserId == userId));
        if (like == null)
        {
            var likeMap = new Like
            {
                CommentId = commentId,
                UserId = userId
            };
            await wrapper.Like.Add(likeMap);
            comment.LikeCount++; await wrapper.Comment.Update(comment);
            return (mapper.Map<LikeDto>(likeMap), null);
        }else
        {
            await wrapper.Like.Delete(like.Id);
            comment.LikeCount--; await wrapper.Comment.Update(comment);
            
            return (mapper.Map<LikeDto>(like), null);
        }
    }
}