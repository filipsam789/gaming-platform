using GamingPlatform.Domain.SportEventDomain.Identity;
using IntegratedSystems.Domain.DomainModels;

namespace GamingPlatform.Domain.SportEventDomain;

public class ShoppingCart : BaseEntity
{
    public string? OwnerId { get; set; }
    public SportEventsAppUser? Owner { get; set; }
    public ICollection<Ticket>? Tickets { get; set; } = new List<Ticket>();

}