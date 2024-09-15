using IntegratedSystems.Domain.DomainModels;

using IntegratedSystems.Domain.DTO;
using IntegratedSystems.Domain.IdentityModels;
using Repository.Interface;
using Service.Interface;

namespace Service.Implementation
{
    public class UserService : IUsersService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public GamingPlatformUser CreateNewUser(GamingPlatformUser user)
        {
            var insertedUser = _userRepository.Insert(user); 
            return insertedUser;
        }

        public GamingPlatformUser DeleteUser(GamingPlatformUser user)
        {
            return _userRepository.Delete(user); 
        }

        public List<Developer> GetDevelopers()
        {
            return _userRepository.GetDevelopers().ToList();
        }

        public GamingPlatformUser GetUserById(Guid? id)
        {
            return _userRepository.Get(id?.ToString());
        }

        public List<GamingPlatformUser> GetUsers()
        {
            return _userRepository.GetAll().ToList();
        }

        public Developer? GetDeveloperById(string id)
        {
            return _userRepository.GetDeveloper(id);
        }

        public GamingPlatformUser UpdateUser(GamingPlatformUser user)
        {
            return _userRepository.Update(user);
        }
    }
}
