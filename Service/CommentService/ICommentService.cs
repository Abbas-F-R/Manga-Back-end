using MangaA.Dto.Comment;
namespace MangaA.Service.CommentService;

public interface ICommentService
{
    Task<( CommentDto? data, string? error)> Add(Guid userId, CommentForm? form); 
    Task<( CommentDto? data, string? error)> GetById(Guid id);
    Task<( List<CommentResponse>? data, int? totalCount, string? error)> GetAll(CommentFilter filter);
    Task<( CommentDto? data, string? error)> Update(Guid userId, Guid id, CommentUpdate? update);
    Task<( CommentDto? data, string? error)> Delete(Guid? userId, Guid id);

 

    
}