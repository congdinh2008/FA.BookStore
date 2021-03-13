using FA.BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FA.BookStore.Core.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public IEnumerable<Book> FindBookByTitle(string title)
        {
            return Context.Books.Where(x => x.Title.Contains(title)).ToList();
        }

        public IEnumerable<Book> FindBookBySummary(string summary)
        {
            return Context.Books.Where(x => x.Summary.Contains(summary)).ToList();
        }

        public IEnumerable<Book> GetLatestBook(int size)
        {
            return Context.Books.OrderByDescending(x => x.CreatedDate).Take(size).ToList();
        }

        public IEnumerable<Book> GetBooksByMonth(DateTime monthYear)
        {
            return Context.Books
                .Where(x => x.CreatedDate.Year == monthYear.Year && x.CreatedDate.Month == monthYear.Month).ToList();
        }

        public int CountBooksForCategory(string category)
        {
            return Context.Books.Count(x => x.Category.Name == category);
        }

        public int CountBooksForPublisher(string publisher)
        {
            return Context.Books.Count(x => x.Publisher.Name == publisher);
        }

        public int CountBooksForAuthor(string author)
        {
            return Context.Books.Count(x => x.Author.Name == author);
        }

        public IEnumerable<Book> GetBooksByCategory(string category)
        {
            return Context.Books.Where(x => x.Category.Name == category).ToList();
        }

        public IEnumerable<Book> GetBooksByPublisher(string publisher)
        {
            return Context.Books.Where(x => x.Publisher.Name == publisher).ToList();
        }

        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            return Context.Books.Where(x => x.Author.Name == author).ToList();
        }
    }
}