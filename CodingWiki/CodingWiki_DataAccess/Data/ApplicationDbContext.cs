using CodingWiki_DataAccess.FluentConfig;
using CodingWiki_Model.Models;
using CodingWiki_Model.Models.FluentModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Tables using Data Annotation
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }

        // Tables using Fluent API
        public DbSet<Fluent_BookDetail> BookDetails_fluent { get; set; }
        public DbSet<Fluent_Book> Books_fluent { get; set; }
        public DbSet<Fluent_Author> Authors_fluent { get; set; }
        public DbSet<Fluent_Publisher> Publishers_fluent { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          //  optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;");
         //       .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Models using Fluent API -  individual config file
            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorMapConfig());

            // Models using data annotation and Fluent API
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);
            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id });

            // Add new Book records to database
            modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Book_Id = 1,
                Title = "Spider Without Duty",
                ISBN = "123B12",
                Price = 10.99m,
                Publisher_Id = 1
            },
            new Book
            {
                Book_Id = 2,
                Title = "Fortune of Time",
                ISBN = "145A22",
                Price = 11.85m,
                Publisher_Id = 2
            });

            var bookList = new Book[]
            {
                new Book { Book_Id = 3, Title = "Fake Sunday", ISBN = "776521", Price = 20.99m, Publisher_Id = 1},
                new Book { Book_Id = 4, Title = "Cookie Jar", ISBN = "C12B33", Price = 17.95m, Publisher_Id = 3},
                new Book { Book_Id = 5, Title = "Cloudy Forest", ISBN = "902F88", Price = 36.20m, Publisher_Id = 2},
            };

            modelBuilder.Entity<Book>().HasData(bookList);

            // Seed Publisher Table
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Publisher_Id = 1, Name = "Pub 1 Jimmy", Location = "Chicago" },
                new Publisher { Publisher_Id = 2, Name = "Pub 2 John", Location = "New York" },
                new Publisher { Publisher_Id = 3, Name = "Pub 3 Ben", Location = "Hawaii" }
            );
        }
    }
}
