using FA.BookStore.Core.Models;
using System.Collections.Generic;

namespace FA.BookStore.Core.Repositories
{
    public interface IAuthorRepository
    {
        Author Find(int authorId);

        int Add(Author author);

        bool Update(Author author);

        bool Delete(Author author);

        IEnumerable<Author> GetAll();
    }
}