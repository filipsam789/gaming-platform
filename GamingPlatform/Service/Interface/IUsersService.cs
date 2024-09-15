using IntegratedSystems.Domain.DomainModels;

using IntegratedSystems.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUsersService
    {
        public List<User> GetUsers();
        public User GetUserById(Guid? id);
        public User CreateNewUser(User user);
        public User UpdateUser(User user);
        public User DeleteUser(User user);
    }
}
