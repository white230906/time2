namespace TetPee.Service.Identity;

public interface IService
{
    public Task<Response.IdentityResponse> Login(Request.Login userLogin);
}