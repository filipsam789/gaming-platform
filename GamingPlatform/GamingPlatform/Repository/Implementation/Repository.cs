using IntegratedSystems.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;


namespace Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> entities;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            if(typeof(T).IsAssignableFrom(typeof(Developer)))
            {
                return entities
                    .Include("Games")
                    .AsEnumerable();
            }
            else if (typeof(T).IsAssignableFrom(typeof(Game)))
            {
                return entities
                    .Include("Developer")
                    .Include("HighScores")
                    .AsEnumerable();
            }
            else if (typeof(T).IsAssignableFrom(typeof(HighScore)))
            {
                return entities
                    .Include("Game")
                    .Include("User")
                    .Include("User.GamingPlatformUser")
                    .AsEnumerable();
            }
            else if (typeof(T).IsAssignableFrom(typeof(User)))
            {
                return entities
                    .Include("HighScores")
                    .AsEnumerable();
            }
            else
            {
                return entities.AsEnumerable();
            }
        }

        public T Get(Guid? id)
        {
            if(typeof(T).IsAssignableFrom(typeof(Developer)))
            {
                return entities
                    .Include("Games")
                    .First(s => s.Id == id);
            }
            else if (typeof(T).IsAssignableFrom(typeof(Game)))
            {
                return entities
                    .Include("Developer")
                    .Include("HighScores")
                    .First(s => s.Id == id);
            }
            else if (typeof(T).IsAssignableFrom(typeof(HighScore)))
            {
                return entities
                    .Include("Game")
                    .Include("Game.Developer")
                    .Include("User")
                    .Include("User.GamingPlatformUser")
                    .First(s => s.Id == id);
            }
            else if (typeof(T).IsAssignableFrom(typeof(User)))
            {
                return entities
                    .Include("HighScores")
                    .First(s => s.Id == id);
            }
            else
            {
                return entities.First(s => s.Id == id);
            }
        }
        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Update(entity);
            context.SaveChanges();
            return entity;
        }

        public T Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
            return entity;
        }

        public List<T> InsertMany(List<T> entitiesToAdd)
        {
            if (entitiesToAdd == null)
            {
                throw new ArgumentNullException(nameof(entitiesToAdd));
            }
            entities.AddRange(entitiesToAdd);
            context.SaveChanges();
            return entitiesToAdd;
        }
    }

}
