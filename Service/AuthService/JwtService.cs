using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace MangaA.Service.AuthService;

public class JwtService(IConfiguration config,IRepositoryWrapper wrapper) : IJwtService
{

    public async Task<(Auth?, string? error)> Register(UserForm request)
    {
        var existingUser = await wrapper.User.Get(u => u.Username == request.Username);
        if (existingUser != null)
            return (null, "Username taken");
        if (request.Password.Length <= 7)
        {
            return (null, "Password must be at least 8 characters long"); 
        }
        string hashPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
        if (string.IsNullOrEmpty(request.Password) || 
            string.IsNullOrEmpty(request.Username) || 
            string.IsNullOrEmpty(request.Name))
        {
            return (null, "All fields are required");
        }

        var user = new User
        {
            Name = request.Name,
            PasswordHash = hashPassword,
            Username = request.Username,
            Role = Role.User,
          
        };
        await wrapper.User.Add(user);
        var token = CreateToken(user);
        var auth = new Auth(user.Username, token);

        Console.WriteLine("Auth: " + auth.Token + "\n" + auth.Username);

        return (auth, null);
    }

    public async Task<(Auth?, string? error)> Login(LoginRequest request)
    {
        // Check if the user exists and verify password
        var userSaved = await wrapper.User.Get(u => u.Username == request.Username);
        if (userSaved == null) 
            return (null, "User not found");
                
        if (!BCrypt.Net.BCrypt.Verify(request.Password, userSaved.PasswordHash)) 
            return (null, "Wrong password");
        
        var token = CreateToken(userSaved);
        var auth = new Auth(userSaved.Username!, token);
        return (auth, null);
    }
  
    public string CreateToken(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        Console.WriteLine("Token UserID: " + user.Id);

        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim("Id", user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            new Claim("Role", user.Role.ToString()),
        };

        var tokenKey = config.GetSection("AppSettings:Token").Value;
        if (string.IsNullOrEmpty(tokenKey))
        {
            throw new InvalidOperationException("Token key is not configured properly.");
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            // issuer: _config["Jwt:Issuer"],
            // audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(10),
            signingCredentials: credentials
        );
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }
    
    

    //
    // public async Task<(Auth?, string? error)> Login(UserDto request)
    // {
    //     var userSaved =  ValidateUserAsync(request.Username).Result;
    //     if (userSaved == null) return (null, "User not found  ");
    //
    //     if (!BCrypt.Net.BCrypt.Verify(request.Password, userSaved.PasswordHash)) return (null, "wrong password");
    //     
    //     string token = CreateToken(userSaved);
    //     RefreshToken refreshToken = GenerateRefreshToken();
    //     var auth = new Auth(userSaved, token, refreshToken);
    //     return (auth, null);
    // }

    // public async Task<(Auth?, string? error)> RefreshToken(string refreshToken)
    // {
    //     var user = await _context.Users
    //         .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
    //     if (user == null) return (null, "user not found");
    //     if (user.TokenExpired < DateTime.Now) return (null, "  Refresh Token expired");
    //
    //     var token = CreateToken(user);
    //     // var newRefreshToken = GenerateRefreshToken();
    //     var auth = new Auth(user, token);
    //     return (auth, null);
    // }
    
    // public RefreshToken GenerateRefreshToken()
    // {
    //     var refreshToken = new RefreshToken
    //     {
    //         Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
    //         Expires = DateTime.Now.AddDays(7)
    //     };
    //     return refreshToken;
    // }
    //
   
}