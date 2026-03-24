using Microsoft.AspNetCore.Mvc;
using TetPee.Repository.Entity;
using TetPee.Service.User;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    private readonly IService _userService;
    
    public UserController(IService userService)
    {
        _userService = userService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateUser([FromBody] Request.UserRequest userRequest)
    {
        var newUser = await _userService.CreateUser(userRequest);
        return Ok(newUser);
    }

    [HttpPut("ChangePassword")]
    public async Task<IActionResult> ChangePassword([FromBody] Request.ChangePasswordRequest changePasswordRequest)
    {
        var result = await  _userService.ChangePassword(changePasswordRequest);
        return Ok(result);
    }
    
}