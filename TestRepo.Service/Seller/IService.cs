namespace TetPee.Service.Seller;

public interface IService
{
    public Task<Response.SellerResponse> CreateSeller(Request.RequestSeller requestSeller);
    public Task<Base.Response.PageResult<Response.SellerResponse>> GetAllSellers(
        string? searchTerm, int pageIndex, int pageSize);
}