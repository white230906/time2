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
         };
    }
}