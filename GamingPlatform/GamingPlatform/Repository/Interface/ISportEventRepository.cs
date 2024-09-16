using IntegratedSystems.Domain.DomainModels;

namespace Repository.Interface
{
    public interface ISportEventRepository<T> where T : BaseEntity
    {
        T Delete(T entity);
        T Get(Guid? id);
        IEnumerable<T> GetAll();
        T Insert(T entity);
        List<T> InsertMany(List<T> entities);
        T Update(T entity);
    }
}