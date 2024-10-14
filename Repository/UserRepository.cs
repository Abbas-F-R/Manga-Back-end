using AutoMapper;
using MangaA.Data;
using MangaA.Interface;
using MangaA.Model;
namespace MangaA.Repository;

public class UserRepository : GenericRepository<User, Guid> , IUserRepository
{
    public UserRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}