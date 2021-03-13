using System;
using FA.BookStore.Core.Models;
using System.Collections.Generic;

namespace FA.BookStore.Core.Repositories
{
    public interface ICategoryRepository
    {
        Category Find(Guid categoryId);

        int Add(Category category);

        bool Update(Category category);

        bool Delete(Category category);

        IEnumerable<Category> GetAll();
    }
}
