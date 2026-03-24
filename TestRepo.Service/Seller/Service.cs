using TetPee.Repository;

namespace TetPee.Service.Seller;

public class Service: IService
{
    private readonly AppDbContext _dbContext;

    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Response.SellerResponse> CreateSeller(Request.RequestSeller requestSeller)
    {
        var user = new Repository.Entity.User()
        {
            Email = requestSeller.Email,
            Password = requestSeller.Password,
            Role = "Seller"
        };
        
        var seller = new Repository.Entity.Seller()
        {
            User = user,
            TaxCode = requestSeller.TaxCode,
            CompanyName = requestSeller.CompanyName,
            CompanyAddress = requestSeller.CompanyAddress,
        };
         await _dbContext.Sellers.AddAsync(seller);
         await _dbContext.SaveChangesAsync();
         return new Response.SellerResponse()
         {
             Email = requestSeller.Email,
         };
    }
}