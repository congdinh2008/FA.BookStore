using System;
using FA.BookStore.Core.Data;
using FA.BookStore.Core.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FA.BookStore.Core.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookStoreContext _context;
        public CategoryRepository()
        {
            _context = new BookStoreContext();
        }
        public Category Find(Guid categoryId)
        {
            return _context.Categories.Find(categoryId);
        }

        public int Add(Category category)
        {
            _context.Categories.Add(category);
            return _context.SaveChanges();
        }

        public bool Update(Category category)
        {
            _context.Categories.AddOrUpdate(category);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(Category category)
        {
            _context.Categories.Remove(category);
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
    }
}