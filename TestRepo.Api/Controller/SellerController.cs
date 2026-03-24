using Microsoft.AspNetCore.Mvc;
using TetPee.Repository.Entity;
using TetPee.Service.Seller;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class SellerController: ControllerBase
{
    private readonly IService _sellerService;
    public SellerController(IService sellerService)
    {
        _sellerService = sellerService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateSeller([FromBody] Request.RequestSeller requestSeller)
    {
        var newSeller = await _sellerService.CreateSeller(requestSeller);
        return Ok(newSeller);
    }
}