
using IntegratedSystems.Domain.DomainModels;
using IntegratedSystems.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    
    public class ApplicationDbContext : IdentityDbContext<GamingPlatformUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       public virtual DbSet<User> Users { get; set; }
       public virtual DbSet<Game> Games { get; set; }
       public virtual DbSet<HighScore> HighScores { get; set; }
       public virtual DbSet<Developer> Developers { get; set; }
       public virtual DbSet<GamingPlatformUser> GamingPlatformUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
       {
           base.OnModelCreating(builder);

            //builder.Entity<GamingPlatformUser>()
            //    .HasDiscriminator<string>("UserType")
            //    .HasValue<GamingPlatformUser>("Base")
            //    .HasValue<User>("User")
            //    .HasValue<Developer>("Developer");

            //builder.Entity<Developer>().HasData(
            //    new Developer
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        FirstName = "Test Developer",
            //        Email = "test@developer.com",
            //        ProgrammingLanguage = "En"
            //
            //    }
            //);

        }
        

    }
    
}
