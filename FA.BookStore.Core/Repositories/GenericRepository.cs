using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using FA.BookStore.Core.Data;

namespace FA.BookStore.Core.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public readonly BookStoreContext Context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository()
        {
            Context = new BookStoreContext();
            _dbSet = Context.Set<TEntity>();
        }
        
        public TEntity Find(Guid id)
        {
            return _dbSet.Find(id);
        }

        public int Add(TEntity entity)
        {
            _dbSet.Add(entity);
            return Context.SaveChanges();
        }

        public bool Update(TEntity entity)
        {
            _dbSet.AddOrUpdate(entity);
            return Context.SaveChanges() > 0;
        }

        public bool Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            return Context.SaveChanges() > 0;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}