using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using FA.BookStore.Core.Data;
using FA.BookStore.Core.Models;

namespace FA.BookStore.Core.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository()
        {
            _context = new BookStoreContext();
        }

        public Book Find(Guid bookId)
        {
            return _context.Books.Find(bookId);
        }

        public int Add(Book book)
        {
            _context.Books.Add(book);
            return _context.SaveChanges();
        }

        public bool Update(Book book)
        {
            _context.Books.AddOrUpdate(book);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(Book book)
        {
            _context.Books.Remove(book);
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public IEnumerable<Book> FindBookByTitle(string title)
        {
            return _context.Books.Where(x => x.Title.Contains(title)).ToList();
        }

        public IEnumerable<Book> FindBookBySummary(string summary)
        {
            return _context.Books.Where(x => x.Summary.Contains(summary)).ToList();
        }

        public IEnumerable<Book> GetLatestBook(int size)
        {
            return _context.Books.OrderByDescending(x => x.CreatedDate).Take(size).ToList();
        }

        public IEnumerable<Book> GetBooksByMonth(DateTime monthYear)
        {
            return _context.Books
                .Where(x => x.CreatedDate.Year == monthYear.Year && x.CreatedDate.Month == monthYear.Month).ToList();
        }

        public int CountBooksForCategory(string category)
        {
            return _context.Books.Count(x => x.Category.Name == category);
        }

        public int CountBooksForPublisher(string publisher)
        {
            return _context.Books.Count(x => x.Publisher.Name == publisher);
        }

        public int CountBooksForAuthor(string author)
        {
            return _context.Books.Count(x => x.Author.Name == author);
        }

        public IEnumerable<Book> GetBooksByCategory(string category)
        {
            return _context.Books.Where(x => x.Category.Name == category).ToList();
        }

        public IEnumerable<Book> GetBooksByPublisher(string publisher)
        {
            return _context.Books.Where(x => x.Publisher.Name == publisher).ToList();
        }

        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            return _context.Books.Where(x => x.Author.Name == author).ToList();
        }
    }
}