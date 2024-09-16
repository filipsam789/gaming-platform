using GamingPlatform.Domain.SportEventDomain;
using GamingPlatform.Domain.SportEventDomain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SportEventDbContext : IdentityDbContext<SportEventsAppUser>
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<TicketInOrder> TicketInOrders { get; set; }

        public SportEventDbContext(DbContextOptions<SportEventDbContext> options)
            : base(options)
        {
        }
    }
}
