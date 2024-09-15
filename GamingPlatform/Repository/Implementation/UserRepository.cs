using IntegratedSystems.Domain.DomainModels;
using Repository.Interface;

namespace Repository.Implementation;
using IntegratedSystems.Domain.IdentityModels;
using Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext context;
    private DbSet<GamingPlatformUser> entities;
    string errorMessage = string.Empty;

    public UserRepository(ApplicationDbContext context)
    {
        this.context = context;
        entities = context.Set<GamingPlatformUser>();
    }
    public IEnumerable<GamingPlatformUser> GetAll()
    {
        return entities.AsEnumerable();
    }

    public GamingPlatformUser? Get(string id)
    {
        return entities
            .SingleOrDefault(s => s.Id == id);
    }
    public GamingPlatformUser Insert(GamingPlatformUser entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        var entityEntry = entities.Add(entity);
        context.SaveChanges();
        return entityEntry.Entity;
    }

    public GamingPlatformUser Update(GamingPlatformUser entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        var entityEntry = entities.Update(entity);
        context.SaveChanges();
        return entityEntry.Entity;
    }

    public GamingPlatformUser Delete(GamingPlatformUser entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        var entityEntry = entities.Remove(entity);
        context.SaveChanges();
        return entityEntry.Entity;
    }
    public IEnumerable<Developer> GetAllDevelopers()
    {
        return context.Set<Developer>().AsEnumerable();
    }

    public Developer GetDeveloper(string id)
    {
        return context.Set<Developer>().SingleOrDefault(d => d.Id == id);
    }

    public IEnumerable<User> GetAllUsers()
    {
        return context.Set<User>().AsEnumerable();
    }

    public User GetUser(string id)
    {
        return context.Set<User>().SingleOrDefault(u => u.Id == id);
    }
}
