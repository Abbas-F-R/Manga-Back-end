namespace MangaA.Service.UserService;

public interface IUserService
{
    Task<(UserResponse? data, string? error)> Get(string username);
    Task<(List<UserResponse>? data, int? totalCount, string? error)> GetAll(UserFilter filter);
    Task<(UserResponse? data, string? error)> Update(UserForm userForm);
    Task<(UserResponse? data, string? error)> DeleteById(Guid id);
    Task<(UserResponse? data, string? error)> AddImageProfile(Guid id, string profileImage); 
    Task<(UserResponse? data, string? error)> DeleteImageProfile(Guid id);



}