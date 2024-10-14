using MangaA.Dto.Comment;
using Microsoft.EntityFrameworkCore;
namespace MangaA.Service.CommentService;

public class CommentService(IRepositoryWrapper wrapper, IMapper mapper) : ICommentService
{

    public async Task<(CommentDto? data, string? error)> Add(Guid userId, CommentForm form)
    {
        if (userId == null)
        {
            return (null, " Cannot Create Comment User not found");
        }
        var user = await wrapper.User.GetById(userId);
        if (user == null)
        {
            return (null, " Cannot Create Comment User not found");
        }
        var comment = mapper.Map<Comment>(form);
        var chapter = await wrapper.Chapter.GetById(form.ChapterId);
        if (chapter == null) return (null, " Chapter Dose not exist ");
        comment.UserId = userId;
        await wrapper.Comment.Add(comment);
        return comment != null ? (mapper.Map<CommentDto>(comment), null) : (null, " Comment cannon created");
    }
    public Task<(CommentDto? data, string? error)> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
    public async Task<(List<CommentResponse>? data, int? totalCount, string? error)> GetAll(CommentFilter filter)
    {
        var (data, totalCount) = await wrapper.Comment.GetAll(c =>
                c.ChapterId == filter.ChapterId,
            include: c => c.Include(x => x.User)!,
            pageNumber: filter.PageNumber, 
            pageSize: filter.PageSize);
        return data != null ?  (mapper.Map<List<CommentResponse>>(data), totalCount, null) : (null , null , " comments not found");
    }
    public async Task<(CommentDto? data, string? error)> Update(Guid userId, Guid id, CommentUpdate? update)
    {
        if (userId == null)
        {
            return (null, " Cannot Create Comment User not found");
        }
        var user = await wrapper.User.GetById(userId);
        if (user == null)
        {
            return (null, " Cannot Create Comment User not found");
        }
        if (update == null || update.CommentText == null)
        {
            return (null, " Cannot Update Comment Comment Text cannot be null");
        }
        var comment = await wrapper.Comment.GetById(id);
        if (comment == null) return (null, " Comment Dose not exist ");
        mapper.Map(update, comment);
        await wrapper.Comment.Update(comment);
        return (mapper.Map<CommentDto>(comment), null);
    }
    public async Task<(CommentDto? data, string? error)> Delete(Guid? userId, Guid id)
    {
        if (userId == null)
        {
            return (null, " Cannot Create Comment User not found");
        }
        var comment = await wrapper.Comment.SoftDelete(id);
        return comment!= null? (mapper.Map<CommentDto>(comment), null) : (null, " Comment Dose not exist ");
    }
}