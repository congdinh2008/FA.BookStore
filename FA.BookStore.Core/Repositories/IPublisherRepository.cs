using System.Collections.Generic;
using FA.BookStore.Core.Models;

namespace FA.BookStore.Core.Repositories
{
    public interface IPublisherRepository
    {
        Publisher Find(int publisherId);

        int Add(Publisher publisher);

        bool Update(Publisher publisher);

        bool Delete(Publisher publisher);

        IEnumerable<Publisher> GetAll();
    }
}