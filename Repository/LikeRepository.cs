namespace MangaA.Repository;

public class LikeRepository : GenericRepository<Like, Guid> , ILikeRepository
{

    public LikeRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}