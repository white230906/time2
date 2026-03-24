namespace TetPee.Service.User;

public class Response
{
    public class UserResponse
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public class ChangePasswordResponse
    {
        public Guid Id { get; set; }
        public string NewPassword { get; set; }
    }
}