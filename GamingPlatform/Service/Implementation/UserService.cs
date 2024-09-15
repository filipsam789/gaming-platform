using IntegratedSystems.Domain.DomainModels;

using IntegratedSystems.Domain.DTO;
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

        public User CreateNewUser(User user)
        {
            var insertedUser = _userRepository.Insert(user); 
            return insertedUser as User;
        }

        public User DeleteUser(User user)
        {
            var deletedUser = _userRepository.Delete(user); 
            return deletedUser as User;
        }

        public User GetUserById(Guid? id)
        {
            var user = _userRepository.Get(id?.ToString());
            return user as User;
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetAll().OfType<User>().ToList();
        }

        public User UpdateUser(User user)
        {
            var updatedUser = _userRepository.Update(user);
            return updatedUser as User;
        }
    }
}
