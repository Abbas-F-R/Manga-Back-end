using MangaA.Dto.Category;
namespace MangaA.Service.CategoryService;

public interface ICategoryService
{
    Task<(CategoryResponse? data, string? error)> Add(Guid userId,CategoryForm form);
    Task<(List<CategoryResponse>? data, int? totalCount, string? error)> GetAll(CategoryFilter filter);

}