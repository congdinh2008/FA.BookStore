using FA.BookStore.Core.Models;
using System;
using System.Collections.Generic;

namespace FA.BookStore.Core.Repositories
{
    public interface ICommentRepository
    {
        Comment Find(Guid commendId);

        int Add(Comment comment);

        bool Update(Comment comment);

        bool Delete(Comment comment);

        IEnumerable<Comment> GetAll();

        IEnumerable<Comment> GetCommentsByBook(Guid bookId);
    }
}
