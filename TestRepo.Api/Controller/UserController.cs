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
}