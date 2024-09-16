using System.Collections;
using GamingPlatform.Domain.SportEventDomain.Identity;
using IntegratedSystems.Domain.DomainModels;

namespace GamingPlatform.Domain.SportEventDomain;

public class Order : BaseEntity
{
    public string OwnerId { get; set; }
    public SportEventsAppUser Owner { get; set; }
    public ICollection<TicketInOrder> TicketsInOrder { get; set; } = new List<TicketInOrder>();
}