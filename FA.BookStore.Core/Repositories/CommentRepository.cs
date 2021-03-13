using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using FA.BookStore.Core.Data;
using FA.BookStore.Core.Models;

namespace FA.BookStore.Core.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BookStoreContext _context;

        public CommentRepository()
        {
            _context = new BookStoreContext();
        }

        public Comment Find(Guid commendId)
        {
            return _context.Comments.Find(commendId);
        }

        public int Add(Comment comment)
        {
            _context.Comments.Add(comment);
            return _context.SaveChanges();
        }

        public bool Update(Comment comment)
        {
            _context.Comments.AddOrUpdate(comment);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(Comment comment)
        {
            _context.Comments.Remove(comment);
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<Comment> GetAll()
        {
            return _context.Comments.ToList();
        }

        public IEnumerable<Comment> GetCommentsByBook(Guid bookId)
        {
            return _context.Comments.Where(x => x.BookId == bookId).ToList();
        }
    }
}