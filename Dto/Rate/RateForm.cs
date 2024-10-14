namespace MangaA.Dto.Rate;

public class RateForm
{
    public required double RateNumber { get; set; }
    public required Guid MangaId { get; set; }
}