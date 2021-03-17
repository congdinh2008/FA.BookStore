using FA.BookStore.Core.Models;
using System;
using System.Collections.Generic;

namespace FA.BookStore.Core.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        IEnumerable<Book> FindBookByTitle(string title);

        IEnumerable<Book> FindBookBySummary(string summary);

        IEnumerable<Book> GetLatestBook(int size);

        IEnumerable<Book> GetBooksByMonth(DateTime monthYear);

        int CountBooksForCategory(string category);

        int CountBooksForPublisher(string publisher);

        int CountBooksForAuthor(string author);

        IEnumerable<Book> GetBooksByCategory(string category);

        IEnumerable<Book> GetBooksByPublisher(string publisher);

        IEnumerable<Book> GetBooksByAuthor(string author);

        IEnumerable<Book> GetBooksWithPaging(int index, int size);

        IEnumerable<Book> GetBooksWithPagingAndFiltering(string searchString, int index, int size);

        IEnumerable<Book> GetBooksWithPagingAndFilteringAndOrdering(string searchString,
            string orderBy, int index, int size);
    }
}
