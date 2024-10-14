namespace MangaA.Service.UserService;

public class UserService(IRepositoryWrapper wrapper, IMapper mapper) : IUserService
{


    public async Task<(UserResponse? data, string? error)> Get(string username)
    {
        var user = await wrapper.User.Get(u => u.Username == username);
        return user != null ? (mapper.Map<User, UserResponse>(user), null) : (null, "User not found");
    }
    public async Task<(List<UserResponse>? data, int? totalCount, string? error)> GetAll(UserFilter filter)
    {
        var (data, totalCount) = await wrapper.User.GetAll(u =>
            (!filter.Role.HasValue || u.Role == filter.Role.Value) &&
            (string.IsNullOrEmpty(filter.Name) || u.Name.Contains(filter.Name)),
            filter.PageNumber, filter.PageSize);

        return data != null ? (mapper.Map<List<UserResponse>>(data), totalCount, null) : (null, null, "user");
    }
    public Task<(UserResponse? data, string? error)> Update(UserForm userForm)
    {
        throw new NotImplementedException();
    }
    public async Task<(UserResponse? data, string? error)> DeleteById(Guid id)
    {
        var date = await wrapper.User.Delete(id);
        return date == null 
            ? (null , "user not found ") 
            :(mapper.Map<UserResponse>(date), null);
    }
    public async Task<(UserResponse? data, string? error)> AddImageProfile(Guid id, string profileImage)
    {
        var user = await wrapper.User.GetById(id);
        if (user == null) return (null, "User not found");
        user.ImageProfile = profileImage;
        await wrapper.User.Update(user);
        return (mapper.Map<User, UserResponse>(user), null);
    }
    public async Task<(UserResponse? data, string? error)> DeleteImageProfile(Guid id)
    {
        var user = await wrapper.User.GetById(id);
        if (user == null) return (null, "User not found");
        user.ImageProfile = "";
        await wrapper.User.Update(user);
        return (mapper.Map<User, UserResponse>(user), null);
    }
}