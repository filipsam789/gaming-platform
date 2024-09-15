using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegratedSystems.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace IntegratedSystems.Domain.DomainModels
{
    public class Developer : BaseEntity
    {
        public virtual GamingPlatformUser GamingPlatformUser { get; set; }
        public string GamingPlatformUserId { get; set; }
        public string ProgrammingLanguage { get; set; } = string.Empty;
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}