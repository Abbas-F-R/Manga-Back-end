
using MangaA.Model;
namespace MangaA.Services.AuthService;

public interface IJwtService
{
    string CreateToken(User user);
    Task<(Auth?, string? error)> Register(UserForm request);
    // RefreshToken GenerateRefreshToken();
    Task<(Auth?, string? error)> Login(LoginRequest request);
    // Task<(Auth?, string? error)> RefreshToken(string refreshToken);
}