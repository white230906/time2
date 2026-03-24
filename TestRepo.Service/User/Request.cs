namespace TetPee.Service.User;

public class Request
{
    public class UserRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
    public class ChangePasswordRequest
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}