using Microsoft.AspNetCore.Mvc;
using TetPee.Service.Category;

namespace TestRepo.Api.Controller;
[ApiController]
[Route("[controller]")]
public class CategoryController: ControllerBase
{
    private readonly IService _service;
    
    public  CategoryController(IService service)
    {
        _service = service;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateCategory([FromBody] Request.CategoryRequest category)
    {
        var result = await _service.CreateCategory(category);
        return Ok(result);
    }
}