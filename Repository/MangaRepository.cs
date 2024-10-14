
namespace MangaA.Repository;

public class MangaRepository : GenericRepository<Manga, Guid> ,IMangaRepository
{
   public MangaRepository( DatabaseContext context, IMapper mapper) : base(context, mapper)
  {
    
  }
}