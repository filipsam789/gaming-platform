using GamingPlatform.Domain.SportEventDomain.Enum;
using IntegratedSystems.Domain.DomainModels;

namespace GamingPlatform.Domain.SportEventDomain;

public class Event : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public EventType EventType { get; set; }
    public Guid? OrganizerId { get; set; }
    public Organizer? Organizer { get; set; }
    public string ImageUrl { get; set; }
    public double EventPrice { get; set; }

    public ICollection<Ticket>? Tickets { get; set; } = new List<Ticket>();
    public int MaximumCapacityEvent { get; set; }
    public int MaximumRegistrations { get; set; }
    public bool OpenForRegistrations { get; set; }

    public ICollection<Registration>? Registrations { get; set; } = new List<Registration>();
}
