using FA.BookStore.Core.Models;
using System;
using System.Collections.Generic;

namespace FA.BookStore.Core.Repositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        IEnumerable<Comment> GetCommentsByBook(Guid bookId);
    }
}
