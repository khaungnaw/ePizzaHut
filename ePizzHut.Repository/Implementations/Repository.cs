using ePizzHut.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ePizzHut.Repository.Implementations
{
    public class Repository<IEntity> : IRepository<IEntity> where IEntity : class
    {
        public readonly DbContext _dbContext;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(IEntity entity)
        {
            _dbContext.Set<IEntity>().Add(entity);
        }

        public void Delete(object Id)
        {
            var entity = _dbContext.Set<IEntity>().Find(Id);
            if(entity != null)
            {
                _dbContext.Set<IEntity>().Remove(entity);
            }
        }

        public IEntity Find(object Id)
        {
            return _dbContext.Set<IEntity>().Find(Id);
        }

        public IEnumerable<IEntity> GetAll()
        {
            return _dbContext.Set<IEntity>().ToList();
        }

        public void Remove(IEntity entity)
        {
            _dbContext.Set<IEntity>().Remove(entity);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public void Update(IEntity entity)
        {
            _dbContext.Set<IEntity>().Update(entity);
        }
    }
}
