using FA.BookStore.Core.Repositories;
using System;

namespace FA.BookStore.DemoConsole
{
    class Program
    {
        private static readonly ICategoryRepository _categoryRepository = new CategoryRepository();
        private static readonly IPublisherRepository _publisherRepository = new PublisherRepository();
        private static readonly IAuthorRepository _authorRepository = new AuthorRepository();
        static void Main(string[] args)
        {
            Console.WriteLine("=========== List Books by context ===========");

            //var books = new List<Book>();
            //using (var context = new BookStoreContext())
            //{
            //    books = context.Books.ToList();
            //}

            //books.ForEach(x => Console.WriteLine(x.Title));

            Console.WriteLine("=========== List Category by Category Repository ===========");

            var categories = _categoryRepository.GetAll();

            foreach (var category in categories)
            {
                Console.WriteLine(category.Name);
            }

            Console.WriteLine("=========== List Author by Author Repository ===========");

            var authors = _authorRepository.GetAll();

            foreach (var author in authors)
            {
                Console.WriteLine(author.Name);
            }

            Console.WriteLine("=========== List Publisher by Publisher Repository ===========");

            var publishers = _publisherRepository.GetAll();

            foreach (var publisher in publishers)
            {
                Console.WriteLine(publisher.Name);
            }

            Console.ReadKey();

        }
    }
}
