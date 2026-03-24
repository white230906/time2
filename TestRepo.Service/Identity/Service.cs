using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TetPee.Repository;
using TetPee.Service.JwtService;

namespace TetPee.Service.Identity;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    private readonly JwtService.IService _jwtService;
    private readonly JwtOptions _jwtOptions = new ();
    public Service(AppDbContext dbContext,  JwtService.IService jwtService, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _jwtService = jwtService;
        configuration.GetSection(nameof(JwtOptions)).Bind(_jwtOptions);
    }
    public async Task<Response.IdentityResponse> Login(Request.Login userLogin)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Email == userLogin.Email);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        if (userLogin.Password != user.Password)
        {
            throw new Exception("Passwords do not match");
        }
        //create Claim
        var claims = new List<Claim>()
        {
            new Claim("UserId", user.Id.ToString()),
            new Claim("Email", user.Email),
            new Claim("password", user.Password),
            new Claim(ClaimTypes.Role, user.Role),
        };
        
        var token = _jwtService.GenerateAccessToken(claims);
        //tao Claim
        //return
        return new Response.IdentityResponse()
        {
            AccessToken = token,
        };
    }
}