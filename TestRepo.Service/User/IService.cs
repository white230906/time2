namespace TetPee.Service.User;

public interface IService
{
    public Task<Response.UserResponse> CreateUser(Request.UserRequest requestUser);
}