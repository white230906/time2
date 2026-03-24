namespace TetPee.Service.Seller;

public interface IService
{
    public Task<Response.SellerResponse> CreateSeller(Request.RequestSeller requestSeller);
}