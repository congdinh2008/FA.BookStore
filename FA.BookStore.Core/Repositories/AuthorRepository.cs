using System;
using FA.BookStore.Core.Data;
using FA.BookStore.Core.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FA.BookStore.Core.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreContext _context;
        public AuthorRepository()
        {
            _context = new BookStoreContext();
        }
        public Author Find(Guid authorId)
        {
            return _context.Authors.Find(authorId);
        }

        public int Add(Author author)
        {
            _context.Authors.Add(author);
            return _context.SaveChanges();
        }

        public bool Update(Author author)
        {
            _context.Authors.AddOrUpdate(author);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(Author author)
        {
            _context.Authors.Remove(author);
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.ToList();
        }
    }
}