using System.Collections.Generic;

namespace ePizzHut.Repository.Interfaces
{
    public interface IRepository<IEntity> where IEntity : class
    {
        IEnumerable<IEntity> GetAll();
        IEntity Find(object Id);
        void Add(IEntity entity);
        void Update(IEntity entity);
        void Remove(IEntity entity);
        void Delete(object Id);
        int SaveChanges();
    }
}
