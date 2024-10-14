using MangaA.Dto.Rate;
namespace MangaA.Service.RateService;

public interface IRateService
{
    Task<(RateDto? data, string? error)> Add(Guid userId, RateForm form);
}