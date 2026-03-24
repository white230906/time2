namespace TetPee.Service.Category;

public interface IService
{
    public Task<Response.CategoryResponse> CreateCategory(Request.CategoryRequest categoryRequest);
    public Task<List<Response.CategoryResponse>> GetAllCategories();
    public Task<List<Response.CategoryResponse>> GetAllChidenCategories(Guid parentId);
}