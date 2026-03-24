namespace TetPee.Service.Category;

public interface IService
{
    public Task<Response.CategoryResponse> CreateCategory(Request.CategoryRequest categoryRequest);
}