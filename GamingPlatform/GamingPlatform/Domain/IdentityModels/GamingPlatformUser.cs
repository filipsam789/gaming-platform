using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegratedSystems.Domain.DomainModels;

namespace IntegratedSystems.Domain.IdentityModels
{
    public class GamingPlatformUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public Developer? Developer { get; set; }
        public string? DeveloperId { get; set; }
        public User? User { get; set; }
        public string? UserId { get; set; }
    }
}
