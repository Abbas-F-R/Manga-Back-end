using MangaA.Dto.Category;
using Microsoft.EntityFrameworkCore;
namespace MangaA.Service.CategoryService;

public class CategoryService(IRepositoryWrapper wrapper, IMapper mapper) : ICategoryService
{

    public async Task<(CategoryResponse? data, string? error)> Add(Guid userId, CategoryForm form)
    {
        var category = mapper.Map<Category>(form);
        var user  = await wrapper.User.GetById(userId);
        if(user == null) return (null, "User not found.");
        var data = await wrapper.Category.Add(category);
        return data != null ? (mapper.Map<CategoryResponse>(data), null) : (null, "Failed to add category.");
    }
    public async Task<(List<CategoryResponse>? data, int? totalCount, string? error)> GetAll(CategoryFilter filter)
    {
       var (data, totalCount) = await wrapper.Category.GetAll(c => 
           (String.IsNullOrEmpty(filter.Name) || 
            EF.Functions.Like(c.Name, $"%{filter.Name}%")),
           filter.PageNumber, filter.PageSize);

        return (data == null || totalCount == 0)
            ? (null, 0, "No categories found")
            : (mapper.Map<List<CategoryResponse>>(data), totalCount, null);
    }
}