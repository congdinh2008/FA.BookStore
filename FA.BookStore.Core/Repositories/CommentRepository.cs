using FA.BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FA.BookStore.Core.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public IEnumerable<Comment> GetCommentsByBook(Guid bookId)
        {
            return Context.Comments.Where(x => x.BookId == bookId).ToList();
        }
    }
}