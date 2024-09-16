using GamingPlatform.Domain.SportEventDomain.Identity;
using IntegratedSystems.Domain.DomainModels;

namespace GamingPlatform.Domain.SportEventDomain;

public class Ticket : BaseEntity
{
    public int Quantity { get; set; }
    public DateTime PurchaseDate { get; set; }
    public String? UserId { get; set; }
    public SportEventsAppUser? User { get; set; }
    public Guid? EventId { get; set; }
    public Event? Event { get; set; }
    public Guid? OrderId { get; set; }
    public Order? Order { get; set; }
    public Guid? ShoppingCartId { get; set; }
    public ShoppingCart? ShoppingCart { get; set; }
}