using CodingWiki_DataAccess.Data;
using CodingWiki_DataAccess.Migrations;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

public class Program
{
    static void Main() { }
}

//using (ApplicationDbContext context = new())
//{
//    context.Database.EnsureCreated();
//    if (context.Database.GetPendingMigrations().Count() > 0 )
//    {
//        context.Database.Migrate();
//    }
//}

// AddBook();
// GetAllBooks();
// GetBook();
// UpdateBook();
// DeleteBook();

//void GetAllBooks()
//{
//    using var context = new ApplicationDbContext();
//    var books = context.Books.ToList();
//    foreach( var book in books )
//    {
//        Console.WriteLine(book.Title + " - " + book.ISBN);
//    }
//}

//async void UpdateBook()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        var book = await context.Books.FindAsync(6);
//        // book.ISBN = "777G16"; // update record
//        // await context.SaveChangesAsync(); // save changes to database

//        var books = await context.Books
//            .Where(u => u.Publisher_Id == 1).ToListAsync();

//        Console.WriteLine("Update Successful!");

//        foreach ( var b in books )
//        {
//            b.Price = 32.75m;
//            Console.WriteLine(b.Title + " - " + b.ISBN);
//        }

//        await context.SaveChangesAsync();
//        // Console.WriteLine(book.Title + " - " + book.ISBN);
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine("Update Failed...");
//        Console.WriteLine(ex.Message);
//    }
//}

//async void DeleteBook()
//{
//    using var context = new ApplicationDbContext();
//    try
//    {
//        var book = await context.Books.FindAsync(8);
//        context.Books.Remove(book);
//        await context.SaveChangesAsync();

//        Console.WriteLine("Deletion Successful!");
//        Console.WriteLine("Record was removed from database.");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine("Deletion Failed...");
//        Console.WriteLine(ex.Message);
//    }
//}

//async void GetBook()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        // Book book = context.Books.FirstOrDefault(); // FirstOrDefault() - get first book record

//        // var input = "Cookie Jar";
//        // var book = context.Books.FirstOrDefault(u => u.Title == input); // FirstOrDefault()

//        // var book = context.Books.Find(6); // Find()

//        var book = await context.Books.SingleAsync(u => u.ISBN == "123B12"); // Single() - filter on specific column. Always return 1 record
//        // var book = context.Books.SingleOrDefault(u => u.Publisher_Id == 66); // Returns null

//        if (book != null )
//        {
//            Console.WriteLine(book.Title + " - " + book.ISBN); // write book to console
//        }
//        else
//        {
//            Console.WriteLine("No book was found.");
//        }

//        // var books = context.Books
//        //    .Where(u => u.Publisher_Id == 3 && u.Price > 10); // Where() - get all books based on a condition

//        // var books = context.Books.Where(u => u.ISBN.Contains("12"));

//        // var books = context.Books.OrderBy(u => u.Title).ThenByDescending(u => u.ISBN).ToList(); // order by title, then order by ISBN

//        var books = await context.Books.Skip(2).Take(2).ToListAsync();

//        foreach (var b in books)
//        {
//            Console.WriteLine(b.Title + " - " + b.ISBN); // write books to console
//        }
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//}

//async void AddBook()
//{
//    Book book = new() { Title = "New EF Core Book", ISBN = "123456", 
//        Price = 55.65m, Publisher_Id = 2 };

//    using var context = new ApplicationDbContext();

//    var books = await context.Books.AddAsync(book);
//    await context.SaveChangesAsync();
//}