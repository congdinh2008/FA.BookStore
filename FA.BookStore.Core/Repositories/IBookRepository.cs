using FA.BookStore.Core.Models;
using System;
using System.Collections.Generic;

namespace FA.BookStore.Core.Repositories
{
    public interface IBookRepository
    {
        Book Find(int bookId);

        int Add(Book book);

        bool Update(Book book);

        bool Delete(Book book);

        IEnumerable<Book> GetAll();

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
    }
}
