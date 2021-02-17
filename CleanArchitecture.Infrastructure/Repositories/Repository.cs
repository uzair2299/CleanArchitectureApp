using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AutoSolutionContext _dbContext;
        protected DbSet<TEntity> Entities;

        public Repository(AutoSolutionContext dbcontext)
        {
            _dbContext = dbcontext;
            Entities = _dbContext.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            Entities.Add(entity);
            return entity;
        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities.AsQueryable();
        }

        public TEntity GetById(int id)
        {
            return Entities.Find(id);
        }

        public bool Remove(int id)
        {
            TEntity existing = Entities.Find(id);
            if (existing != null)
            {
                Entities.Remove(existing);
                return true;
            }
            else
                return false;
        }

        public void Update(TEntity entity)
        {

           // _dbContext.Entry(entity).State = EntityState.Detached;
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
