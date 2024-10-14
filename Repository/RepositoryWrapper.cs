
namespace MangaA.Repository;

public class RepositoryWrapper(DatabaseContext context, IMapper mapper) : IRepositoryWrapper
{

  
    private IUserRepository? _user;
    private IMangaRepository? _manga;
    private IChapterRepository? _chapter;
    private ICategoryRepository? _category;
    private IRateRepository? _rate;
    private ITagRepository? _tag;
    private ILikeRepository? _like; 
    private ICommentRepository? _comment;
    public IUserRepository User => _user ??= new UserRepository(context, mapper);
    public IMangaRepository Manga => _manga ??= new MangaRepository(context, mapper);
    public IChapterRepository Chapter => _chapter ??= new ChapterRepository(context, mapper);
    public ICategoryRepository Category => _category ??= new CategoryRepository(context, mapper);
    public IRateRepository Rate => _rate??= new RateRepository(context, mapper);
    public ITagRepository Tag => _tag??= new TagRepository(context, mapper);
    public ILikeRepository Like => _like??= new LikeRepository(context, mapper);  // Add like repository here.
    public ICommentRepository Comment => _comment??= new CommentRepository(context, mapper); // Add comment repository here.
    

}