namespace MangaA.Repository;

public class RateRepository : GenericRepository<Rate, Guid>  , IRateRepository
{

    public RateRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}