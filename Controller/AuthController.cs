using Microsoft.AspNetCore.Mvc;

namespace MangaA.Controller;

[Route("api/[Controller]")]
[ApiController]
public class AuthController(IJwtService jwtService, IUserService userService) : BaseController
{
 
    [HttpPost("register")]
    public async Task<ActionResult> Register(UserForm request) => Ok(await jwtService.Register(request) );
    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginRequest request) => Ok(await jwtService.Login(request));
    [HttpGet("user/{username}")]
    public async Task<ActionResult<UserResponse>> Get(string username) => Ok( await userService.Get(username));
    [HttpGet ("")]
    public async Task<ActionResult<Respons<UserResponse>>> GetAll([FromQuery] UserFilter filter) => Ok(await userService.GetAll(filter));
    [HttpDelete("/{id}")]
    public async Task<ActionResult> Delete(Guid id) => Ok(await userService.DeleteById(id));
    [HttpPost("imageProfile")]
    public async Task<ActionResult<UserResponse>> AddImageProfile(string profileImage) => Ok( await userService.AddImageProfile(Id, profileImage));
    [HttpDelete("imageProfile")]
    public async Task<ActionResult<UserResponse>> DeleteImageProfile(string profileImage) => Ok( await userService.DeleteImageProfile(Id));


    // [HttpPost("refresh_Token")]
    // public async Task<ActionResult<(Auth?, string? error)>> RefreshToken() => Ok()
    // {
    //     try
    //     {
    //         var refreshToken = Request.Cookies["refreshToken"];
    //         if (string.IsNullOrEmpty(refreshToken))
    //         {
    //             return BadRequest(new { message = "Refresh token is missing" });
    //         }
    //
    //         var auth = await _jwtService.RefreshToken(refreshToken);
    //         await SetRefreshToken(auth.RefreshToken, auth.User);
    //         return Ok(auth.Token);
    //     }
    //     catch (Exception ex)
    //     {
    //         return BadRequest(new { message = ex.Message });
    //     }
    // }

    // private async Task SetRefreshToken(RefreshToken newRefreshToken, User user)
    // {
    //     var cookieOptions = new CookieOptions
    //     {
    //         HttpOnly = true,
    //         Expires = newRefreshToken.Expires
    //     };
    //     Response.Cookies.Append("RefreshToken", newRefreshToken.Token, cookieOptions);
    //     user.RefreshToken = newRefreshToken.Token;
    //     user.TokenCreated = newRefreshToken.Created;
    //     user.TokenExpired = newRefreshToken.Expires;
    //     await _context.SaveChangesAsync();
    // }
}