using IntegratedSystems.Domain.DomainModels;
using IntegratedSystems.Domain.IdentityModels;

namespace Repository.Interface;

public interface IUserRepository
{
    IEnumerable<GamingPlatformUser> GetAll();
    GamingPlatformUser? Get(string? id);
    GamingPlatformUser Insert(GamingPlatformUser entity);
    GamingPlatformUser Update(GamingPlatformUser entity);
    GamingPlatformUser Delete(GamingPlatformUser entity);
    
    IEnumerable<Developer> GetAllDevelopers();
    Developer GetDeveloper(string id);
    IEnumerable<User> GetAllUsers();
    User GetUser(string id);
}