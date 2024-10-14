namespace MangaA.Repository;

public class CategoryRepository : GenericRepository<Category, Guid> , ICategoryRepository
{
    public CategoryRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}