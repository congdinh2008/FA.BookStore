﻿using FA.BookStore.Core.Migrations;
using FA.BookStore.Core.Models;
using System.Data.Entity;

namespace FA.BookStore.Core.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext() : base("name=BookStoreConn")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookStoreContext, Configuration>());
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
