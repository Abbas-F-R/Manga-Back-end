namespace MangaA.Model;

public class Rate : BaseEntity
{
    public double? RateNumber { get; set; }
    public Guid? UserId { get; set; }
    public Guid? MangaId { get; set; }
}