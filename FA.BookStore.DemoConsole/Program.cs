using FA.BookStore.Core.Data;
using FA.BookStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FA.BookStore.DemoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new List<Book>();
            using (var context = new BookStoreContext())
            {
                books = context.Books.ToList();
            }

            books.ForEach(x => Console.WriteLine(x.Title));
            Console.ReadKey();
        }
    }
}
