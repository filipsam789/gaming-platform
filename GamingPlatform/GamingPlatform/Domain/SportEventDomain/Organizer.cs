using IntegratedSystems.Domain.DomainModels;

namespace GamingPlatform.Domain.SportEventDomain;
public class Organizer : BaseEntity
{
    public string Name { get; set; }
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }
    public string Address { get; set; }
    public ICollection<Event>? Events { get; set; } = new List<Event>();
}