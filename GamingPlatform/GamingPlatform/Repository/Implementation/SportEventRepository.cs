using GamingPlatform.Domain.SportEventDomain;
using IntegratedSystems.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class SportEventRepository<T> : ISportEventRepository<T> where T : BaseEntity
    {
        private readonly SportEventDbContext context;
        private DbSet<T> _entities;

        public SportEventRepository(SportEventDbContext context)
        {
            this.context = context;
            _entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _entities;

            if (typeof(T).IsAssignableFrom(typeof(Event)))
            {
                query = query.Include("Organizer");
            }

            return query;
        }

        public T Get(Guid? id)
        {
            IQueryable<T> query = _entities;

            if (typeof(T).IsAssignableFrom(typeof(Event)))
            {
                query = query
                    .Include("Organizer");
            }

            return query.FirstOrDefault(s => s.Id == id);
        }
        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _entities.Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _entities.Update(entity);
            return entity;
        }

        public T Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _entities.Remove(entity);
            return entity;
        }

        public List<T> InsertMany(List<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            _entities.AddRange(entities);
            return entities;
        }
    }
}
