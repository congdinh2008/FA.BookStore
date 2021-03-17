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

        public IEnumerable<Book> GetBooksWithPaging(int index, int size)
        {
            return Context.Books.OrderBy(x => x.Title).Skip(size * (index - 1))
                .Take(size).ToList();
        }

        public IEnumerable<Book> GetBooksWithPagingAndFiltering(string searchString, int index, int size)
        {
            return Context.Books.Where(x => x.Title.Contains(searchString) ||
                                            x.Summary.Contains(searchString))
                .OrderBy(x => x.Title).Skip(size * (index - 1)).Take(size).ToList();
        }

        public IEnumerable<Book> GetBooksWithPagingAndFilteringAndOrdering(
            string searchString, string orderByString, int index, int size)
        {
            Func<IQueryable<Book>, IOrderedQueryable<Book>> orderBy = null;


            if (orderByString == "Title_desc")
            {
                orderBy = b => b.OrderByDescending(s => s.Title);
            }

            if (orderByString == "Title_asc")
            {
                orderBy = b => b.OrderBy(s => s.Title);
            }

            if (orderByString == "CreatedDate_asc")
            {
                orderBy = b => b.OrderBy(s => s.Title);
            }

            if (orderByString == "CreatedDate_desc")
            {
                orderBy = b => b.OrderByDescending(s => s.Title);
            }

            var query = Context.Books.Where(x => x.Title.Contains(searchString) ||
                                                 x.Summary.Contains(searchString));
            query = orderBy(query);

            return query.Skip(size * (index - 1)).Take(size).ToList();
        }
    }
}