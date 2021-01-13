using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity:class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        bool Remove(int id);

    }
}
