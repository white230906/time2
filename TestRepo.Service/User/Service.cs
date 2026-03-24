using Microsoft.EntityFrameworkCore;
using TetPee.Repository;

namespace TetPee.Service.User;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    
    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Response.UserResponse> CreateUser(Request.UserRequest requestUser)
    {
        var user = new Repository.Entity.User()
        {
            Email = requestUser.Email,
            Password = requestUser.Password
        };
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return new Response.UserResponse()
        {
            Email = user.Email,
        };
    }

    public async Task<Response.ChangePasswordResponse> ChangePassword(Request.ChangePasswordRequest requestUser)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == requestUser.Email);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        if (user.Password != requestUser.OldPassword)
        {
            throw new Exception("Passwords do not match");
        }
        user.Password = requestUser.NewPassword;
         _dbContext.Users.Update(user);
         await _dbContext.SaveChangesAsync();
         return new Response.ChangePasswordResponse()
         {
             Id = user.Id,
             NewPassword = requestUser.NewPassword
         };
    }
}