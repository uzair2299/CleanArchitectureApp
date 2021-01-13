using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
