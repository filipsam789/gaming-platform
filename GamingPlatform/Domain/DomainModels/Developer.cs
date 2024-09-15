using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegratedSystems.Domain.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace IntegratedSystems.Domain.DomainModels
{
    public class Developer : GamingPlatformUser
    {
        public string ProgrammingLanguage { get; set; }
        public ICollection<Game> Games { get; set; } =  new List<Game>();
    }
}