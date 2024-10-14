using MangaA.Dto.Tag;
using Microsoft.EntityFrameworkCore;
namespace MangaA.Service.TagService;

public class TagService(IRepositoryWrapper wrapper, IMapper mapper) : ITagService
{

   
    // Add Tag Method
    public async Task<(TagResponse? data, string? error)> Add(Guid userId,TagForm form)
    {
        var tag = mapper.Map<Tag>(form);
        var user  = await wrapper.User.GetById(userId);
        if(user == null) return (null, "User not found.");
        var data = await wrapper.Tag.Add(tag);
        return data != null ? (mapper.Map<TagResponse>(data), null) : (null, "Failed to add tag.");
    }

    // GetAll Tags Method
    public async Task<(List<TagResponse>? data, int? totalCount, string? error)> GetAll(TagFilter filter)
    {
        var (data, totalCount) = await wrapper.Tag.GetAll(t => 
                string.IsNullOrEmpty(filter.Name) || 
                 EF.Functions.Like(t.Name, $"%{filter.Name}%"),
            filter.PageNumber, filter.PageSize);

        return (data == null || totalCount == 0)
            ? (null, 0, "No tags found")
            : (mapper.Map<List<TagResponse>>(data), totalCount, null);
    }
    

}