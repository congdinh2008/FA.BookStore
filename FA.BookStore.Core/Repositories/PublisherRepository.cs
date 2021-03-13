using System;
using FA.BookStore.Core.Data;
using FA.BookStore.Core.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FA.BookStore.Core.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly BookStoreContext _context;
        public PublisherRepository()
        {
            _context = new BookStoreContext();
        }
        public Publisher Find(Guid publisherId)
        {
            return _context.Publishers.Find(publisherId);
        }

        public int Add(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            return _context.SaveChanges();
        }

        public bool Update(Publisher publisher)
        {
            _context.Publishers.AddOrUpdate(publisher);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(Publisher publisher)
        {
            _context.Publishers.Remove(publisher);
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _context.Publishers.ToList();
        }
    }
}