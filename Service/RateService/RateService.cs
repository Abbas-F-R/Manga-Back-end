using MangaA.Dto.Rate;
namespace MangaA.Service.RateService;

public class RateService(IRepositoryWrapper wrapper, IMapper mapper) : IRateService
{

    public async Task<(RateDto? data, string? error)> Add(Guid userId, RateForm form)
    {

        Console.WriteLine( "MangaId : " + form.MangaId);
        var manga = await wrapper.Manga.GetById(form.MangaId);
        if (manga == null)
        {
            return (null, "Manga not found");
        }
        var user = await wrapper.User.GetById(userId);
        if (user == null)
        {
            return (null, "User not found");
        }
        if (form.RateNumber > 5.0 || form.RateNumber < 1.0)
        {
            return (null, "Rate number should be between 1 and 5");
        }
        var existingRate = await wrapper.Rate.Get(r => r.MangaId == form.MangaId  && r.UserId == userId);
        if (existingRate != null)
        {
            existingRate.RateNumber = form.RateNumber;
            wrapper.Rate.Update(existingRate);

            return (mapper.Map<RateDto>(existingRate), null);

        }

        var rate = mapper.Map<Rate>(form);
        rate.UserId = userId;
        var result = await wrapper.Rate.Add(rate);
        if (result == null)
        {
            return (null, "Error Rate adding");
        }
        return (mapper.Map<RateDto>(result), null);
    }
    
}