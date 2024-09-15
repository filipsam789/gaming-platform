using IntegratedSystems.Domain.DomainModels;

using IntegratedSystems.Domain.DTO;
using IntegratedSystems.Domain.IdentityModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUsersService
    {
        public List<GamingPlatformUser> GetUsers();
        public List<Developer> GetDevelopers();
        public GamingPlatformUser GetUserById(Guid? id);
        public GamingPlatformUser CreateNewUser(GamingPlatformUser user);
        public GamingPlatformUser UpdateUser(GamingPlatformUser user);
        public GamingPlatformUser DeleteUser(GamingPlatformUser user);
        public Developer? GetDeveloperById(string id);
    }
}
