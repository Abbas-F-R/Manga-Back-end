namespace MangaA.Repository;

public class CommentRepository : GenericRepository<Comment, Guid> , ICommentRepository
{

    public CommentRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}