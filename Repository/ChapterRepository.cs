namespace MangaA.Repository;

public class ChapterRepository : GenericRepository<Chapter, Guid> ,IChapterRepository
{
    public ChapterRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}