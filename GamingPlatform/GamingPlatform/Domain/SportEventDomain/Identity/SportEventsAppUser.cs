using Microsoft.AspNetCore.Identity;
using Order = GamingPlatform.Domain.SportEventDomain.Order;

namespace GamingPlatform.Domain.SportEventDomain.Identity;

public class SportEventsAppUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public ShoppingCart? ShoppingCart { get; set; } = new ShoppingCart();
    public ICollection<Order> Orders { get; set; }
    public ICollection<Registration>? Registrations { get; set; }
}