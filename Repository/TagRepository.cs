namespace MangaA.Repository;

public class TagRepository : GenericRepository<Tag,Guid>, ITagRepository
{

    public TagRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}