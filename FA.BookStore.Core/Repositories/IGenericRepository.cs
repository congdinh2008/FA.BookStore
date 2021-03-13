using System;
using System.Collections.Generic;

namespace FA.BookStore.Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Find(Guid id);

        int Add(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(TEntity entity);

        IEnumerable<TEntity> GetAll();
    }
}
