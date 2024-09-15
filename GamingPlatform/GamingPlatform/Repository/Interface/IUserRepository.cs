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
    public Developer? GetDeveloper(string id);
    public IEnumerable<User> GetUsers();
    public IEnumerable<Developer> GetDevelopers();

}