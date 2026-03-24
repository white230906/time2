using Microsoft.EntityFrameworkCore;
using TetPee.Repository;

namespace TetPee.Service.Category;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    
    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Response.CategoryResponse> CreateCategory(Request.CategoryRequest categoryRequest)
    {
        var category = new Repository.Entity.Category()
        {
            Name = categoryRequest.Name,
            ParentId = categoryRequest.ParentId
        };
         await _dbContext.Categories.AddAsync(category);
         await  _dbContext.SaveChangesAsync();
         return new Response.CategoryResponse()
         {
             Name = category.Name,
             Id = category.Id,
         };
    }

    public async Task<List<Response.CategoryResponse>> GetAllCategories()
    {
        var query =  _dbContext.Categories.Where(x => true);
        query = query.OrderBy(x => x.Name);
        var selectedQuery = query.Select(x => new Response.CategoryResponse()
        {
            Name = x.Name,
            Id = x.Id,
        });
        var result = await selectedQuery.ToListAsync();
        return result;
    }

    public async Task<List<Response.CategoryResponse>> GetAllChidenCategories(Guid parentId)
    {
        var query = _dbContext.Categories.Where(x => x.ParentId == parentId);
        query = query.OrderBy(x => x.Name);
        var selectedQuery = query.Select(x => new Response.CategoryResponse()
        {
            Name = x.Name,
            Id = x.Id,
        });
        var result = await selectedQuery.ToListAsync();
        return result;
    }
}