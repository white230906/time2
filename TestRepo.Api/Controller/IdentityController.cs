using Microsoft.AspNetCore.Mvc;
using TetPee.Service.Identity;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class IdentityController: ControllerBase
{
    private readonly IService _identityService;
    
    public IdentityController(IService identityService)
    {
        _identityService = identityService;
    }

    [HttpGet("")]
    public async Task<IActionResult> Login([FromQuery] Request.Login login)
    {
        var accessToken = await _identityService.Login(login);
        return Ok(accessToken);
    } 
}