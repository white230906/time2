using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestRepo.Api.Extensions;
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
    [Authorize(Policy = JwtExtensions.AdminPolicy)]
    [HttpGet("")]
    public async Task<IActionResult> GetSellers(string? searchTerm, int pageIndex = 1, int pageSize = 10)
    {
        var result = await _sellerService.GetAllSellers(searchTerm, pageIndex, pageSize);
        return Ok(result);
    }
}