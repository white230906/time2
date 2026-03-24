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
}