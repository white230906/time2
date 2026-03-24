using Microsoft.EntityFrameworkCore;
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
             Password = requestSeller.Password,
             Role = "Seller",
         };
    }

    public async Task<Base.Response.PageResult<Response.SellerResponse>> GetAllSellers(string? searchTerm, int pageIndex, int pageSize)
    {
        var query = _dbContext.Sellers.Where(x => true);
        if (searchTerm != null)
        {
            query = query.Where(x => x.User.Email.Contains(searchTerm));
        }
        query = query.OrderBy(x => x.User.Email);
        query = query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);
        var selectedQuery = query.Select(x => new Response.SellerResponse()
        {
            Email = x.User.Email,
            Password = x.User.Password,
            Role = "Seller",
        });
        var resultList =  await selectedQuery.ToListAsync();
        var totalItems = resultList.Count;
        var result = new Base.Response.PageResult<Response.SellerResponse>()
        {
            Items = resultList,
            TotalItems = totalItems,
            PageIndex = pageIndex,
            PageSize = pageSize,
        };

        return result;
    }
}