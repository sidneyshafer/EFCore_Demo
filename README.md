# CodingWiki Project
* [Entity Framework Core Overview](#entity-framework-core-overview)
* [LINQ Query Methods](#linq-query-methods)
* [Projections](#projections)
* [IQueryable](#iqueryable)
* [Loading of Related Data](#loading-of-related-data)
* [CodingWiki EF Core Details](#codingwiki-ef-core-details)

## Entity Framework Core Overview

Entity Framework Core is a Cross-Platform, Open-Source Object Relational Mapper (ORM)

**What is ORM?**
*	ORM stands for Object to Relational Mapping
    *	**Object:** classes that we create in our programming language (C#, Java, Python etc.)
    *	**Relational:** the Relational Database Management System like MS-SQL, MySQL etc.
    *	**Mapping:** the part which bridges objects and database tables.
*	ORM is a technique that lets you query and manipulate data from a database using an object-oriented paradigm of your preferred programming language.
*	Typically, ORM simplifies a query. 
*	It allows us to interact with a database using a programming language of choice, instead of SQL. 

**Advantages of ORM**
*	You get to write in the language you are already using anyway.
*	It abstracts away the database system so that switching databases is not that difficult.
*	Many of the queries/commands you write with the help of ORM will perform better than if you wrote them yourself.
*	Saves you time as compared to writing SQL and Wrappers.
*	It can generate a database from models.

**Entity Framework Core Introduction**
*	Entity Framework Core is the new version of Entity Framework after EF 6.x.
*	It is an open-source, lightweight, extensible, and cross-platform version of Entity Framework data access technology.
*	Entity Framework Core is an ORM.
*	It is an enhancement to ADO.NET that gives developers an automated mechanism for accessing and storing the data in a database.
*	You can write your queries using LINQ as compared to SQL.

**Advantages of Entity Framework**
*	Generate models based on a database and vice versa.
*	Saves time from repetitive tasks.
*	More secure.
*	Cross platform.
*	Do not need to manage mappings manually.
*	Do not need stored procedures. However, Entity Framework Core does provide the flexibility to execute stored procedures if necessary.

**New ASP.NET Core Web App (MVC)**
*	When creating a new ASP.NET Core Web App in Visual Studio, if you select *Individual Account* under **Authentication type**, Entity Framework Core will automatically be configured in the application.

**Migrations in EF Core**
1.	<u>Change/Create Model</u>: You should first create a new model or change any existing model.
2.	<u>Add Migration</u>: Add a new migration once you make your changes to see what will be pushed to the database.
3.	<u>Apply Migration</u>: Once a migration is added use update-database command to push migration.

**Migration Scenarios**
*If you create a new migration without any changes to the project, EF Core will generate an empty migration file. **Below are examples of scenarios of when it is appropriate to add a new migration.***
*	A new class, a new table in the database needs to be added.
*	A new property added to a class, a new column needs to be added to the table.
*	Modifications to an existing property, a new migration needs to update the table column.
*	Deletion of an existing property, a new migration needs to update the table column.
*	Deletion of a class, table in the database must be updated.

***Always make small changes and small migrations when working with EF Core.***

**Data Annotations**
| Annotation | Namespace | Description |
| --- | --- | --- |
| [Table(“table_name”)]	|System.ComponentModel.DataAnnotations.Schema	| Defines a table name |
| [Column(“column_name”)] |	System.ComponentModel.DataAnnotations.Schema |	Defines a column name |
| [Required] | System.ComponentModel.DataAnnotations |	Defines a required field |
| [Key] | System.ComponentModel.DataAnnotations	| Defines a primary key |
| [MaxLength(50)] |	System.ComponentModel.DataAnnotations |	Defines a max length |
| [NotMapped] |	System.ComponentModel.DataAnnotations.Schema | Property should not be added as a new column |

**Common Migration Commands**
|  |  |
| --- | --- |
| Add-Migration [MigrationName] |	Add a new migration. |
| Update-Database [MigrationName] |	Update the database. Can include an optional migration name after the command to update the database based on a certain migration. |
| Get-Migration |	Returns a table (id, name, safeName, and applied) of all migration files. |
| Drop-Database |	Delete the database. Use the `Update-Database` command to revert drop command. |

----
## LINQ Query Methods

**Common Methods**
|  |  |
| --- | --- |
| First() |	Retrieves the first element of a sequence that satisfies a specified condition. Throws an exception if no matching element is found in the sequence. |
| FirstOrDefault() |	Retrieves the first element of a sequence that satisfies a specified condition, or a default value (usually ‘null’) if no such element is found. |
| Where() |	Retrieves all elements from a sequence that satisfy the specified condition. |
| Find() |	Retrieves an entity by its primary key. |
| Single() |	Retrieves a single element from a sequence that satisfies a specified condition. It ensures that there is exactly one element matching the condition, and if there are more or fewer than one matching element, it throws an exception. |
| SingleOrDefault() |	Retrieves a single element from a sequence that satisfies a specified condition, or a default value if no such element is found. If there is more than one element matching the condition, it throws an exception. |
| Contains() | Checks whether a sequence contains a specific element. Commonly used to perform filtering based on a collection of values. |
| Max() |	Finds the maximum value in a sequence of elements. |
| Min() |	Finds the minimum value in a sequence of elements. |
| Count() |	Returns an integer value representing the number (count) of elements in a sequence. |
| OrderBy() |	Sorts the elements of a sequence in ascending order based on a specified key. Returns a new sequence where the elements are ordered according to the specified key. |
| ThenByDescending() |	Performs a secondary sort on elements of a sequence that have already been ordered by a primary sort key, in descending order (typically used after an initial `OrderBy()`). |
| Skip() and Take() |	Used to implement paging or portioning data.<br />**Skip():** skips a specified number of elements in a sequence and returns the remaining elements.<br />**Take():** returns a specified number of contiguous elements from a sequence starting from the beginning. |

----
## Projections

Projection is a way of converting an entity into a C# class with a subset of those properties.

## IQueryable
*	IQueryable interface inherits from IEnumerable.
*	Anything you do with IEnumerable can be done with IQueryable.
*	For example, when using IEnumerable in a query to retrieve a list of filtered records, the records are returned by the database and then filter is applied in memory (on client side). When using IQuerable in a query to retrieve a list of filtered records, the database filters and returns the records.

## Loading of Related Data
*	**Explicit Loading:** related data is loaded in a separate query.
	*	More queries executed
	*	Reference/Collection methods
*	**Eager Loading:** related data is loaded in the initial query itself.
	*	Single query execution
	*	Include() / ThenInclude()
*	**Lazy Loading:** related data is loaded when navigation property is accessed.
	*	UseLazyLoadingProxies()
	*	Virtual navigation properties

[Back to Top](#codingwiki-project) :arrow_up:

----
## CodingWiki EF Core Details
* [NuGet Packages](#nuget-packages)
* [Db Context and Migrations](#db-context-and-migrations)
* [Relations](#relations)
* [Using Fluent API](#using-fluent-api)
* [EF Core in Console Project](#ef-core-in-console-project)

### NuGet Packages
EF Core NuGet packages used in **CodingWiki_DataAccess** project.
  ```csharp
  Microsoft.EntityFrameworkCore.SQLServer
  Microsoft.EntityFrameworkCore.Tools
  ```
NuGet package in **CodingWiki_Web** project.
  ```csharp
 	Microsoft.EntityFrameworkCore.Design
  ```

----
### Db Context and Migrations

**Add DbContext Class**
*	Create a DbContext class to work with EF Core and interact with database tables.
*	Create the **ApplicationDbContext** class that inherits from DbContext in the **CodingWiki_DataAccess** project.
	   * DbContext is responsible for providing all the logic needed for working with EF Core (e.g. creating, retrieving, updating, or deleting data from a database).
  ```csharp
  public class ApplicationDbContext : DbContext
  ```
*	Create DbSet in ApplicationDbContext class.
      * DbSet represents the classes (or models) of the tables we want in our application.
  ```csharp
  public DbSet<Book> Books { get; set; }
  ```

**Configure A Connection String**
Override the OnConfiguring method of the DbContext class.
  ```csharp
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
      optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection:True;");
  }
  ```

**Add Migrations**
*	Right click CodingWiki_DataAccess project and select **Set as Startup Project**.
*	Open the Package Manager Console and set the default project to CodingWiki_DataAccess.
*	Add a new migration.
  ```csharp
  Add-Migration AddBookToDb
  ```
*Migration files can be found under the project **Migrations** folder.*

**Create Database and Apply Migration**
* Create a new database and add migration by running `Update-Database` command in the NuGet Package Manager Console.

**Remove Migration**
* If you have not pushed a migration to the database, you can use the `Remove-Migration` command to remove it.

**Remove a Class/Table from Db**
*Good practice to never remove migration files directly from the Migrations folder in Solution Explorer. Always make changes in the application models or DbContext.*
1. Navigate to application DbContext and remove the previously defined DbSet.
2. Add a new migration (EF Core will see the DbSet has been removed and it will drop table from database).
3. Update the database.

**Rolling Back to Old Migrations**
* In the Package Manager Console window, update the database followed by the name of migration you want to roll back too.
  ```csharp
  Update-Database AddCategoryToDb
  ```
* Used for development (not production). Tables/data may be deleted with migration roll back.
* To revert to the latest migration version, run the `Update-Database` command.

----
### Relations
**One to One** – Book and BookDetail *(each book can only have one book detail, and each book detail can only have one book)*.
* Add navigation and Id properties to the BookDetail class to refer to a Book entity as a foreign key.
  ```csharp
  [ForeignKey("Book")]
  public int Book_Id { get; set; }
  public Book Book { get; set; }
  ```
* Add a navigation property to the Book class to refer to BookDetail and establish a one-to-one relationship.
  ```csharp
  public BookDetail BookDetail { get; set; }
  ```

**One to Many** – Book and Publisher *(a publisher can publish multiple books, and a book can only have one publisher)*.
* Add navigation and Id properties to the Book class to refer to a Publisher entity as a foreign key and establish a one-to-many relationship.
  ```csharp
  [ForeignKey("Publisher")]
  public int Publisher_Id { get; set; }
  public Publisher Publisher { get; set; }
  ```
* Add a collection of Book property to the Publisher class to retrieve a list of all Books a publisher has published based on the foreign key relation.
  ```csharp
  public List<Book> Books { get; set; }
  ```
  
**Many to Many** – Automatic Mapping for Book and Author *(a book can have multiple authors, and authors can have multiple books)*.
* Add navigation property to Author class, referring to the Book entity.
  ```csharp
  public List<Book> Books { get; set; }
  ```
* Add navigation property to Book class, referring to the Author entity.
  ```csharp
  public List<Author> Authors { get; set; }
  ```
	* *EF Core will automatically generate a mapping table between the Book and Author tables.*

**Many to Many** – Manual Mapping for Book and Author.
* Create a BookAuthorMap class that will act as the mapping class between Books and Authors.
  ```csharp
	public class BookAuthorMap
	{
	    [ForeignKey("Book")]
	    public int Book_Id { get; set; }
	    [ForeignKey("Author")]
	    public int Author_Id { get; set; }
	
	    public Book Book { get; set; }
	    public Author Author { get; set; }
	}
  ```
* Modify the navigation property in the Book class to reference mapping class.
  ```csharp
  public List<BookAuthorMap> Authors { get; set; }
  ```
* Modify the navigation property in the Author class to reference mapping class.
  ```csharp
  public List<BookAuthorMap> Books { get; set; }
  ```
* Define a composite key for mapping class in the OnModelCreating method of application DbContext.
  ```csharp
  modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id });
  ```

----
### Using Fluent API

CodingWiki presents the use of creating database entities using Fluent API. With this, we can define table and column names, set primary and foreign keys, specify certain column validation rules, and establish relationships between entities without using data annotation. The tables in this project are based off previously defined models. 

**Add Fluent Models**
*	Create fluent models that are based on the previously defined models (that use data annotation).
	*	*Copy the following models: Author, Book, BookDetail, Publisher, and BookAuthorMap classes.*
*	Store in a separate folder named **FluentModels** under the **Models** folder.
*	Remove all data annotations (if applicable) in each model class.

**Config Files**
*	Create a configuration file for each entity that will contain code for working with Fluent API. 
*	Store all config files in a folder named **FluentConfig** under the Data Access project.
*	In the **ApplicationDbContext**, apply each configuration.
  	```csharp
	modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
	modelBuilder.ApplyConfiguration(new FluentBookConfig());
	modelBuilder.ApplyConfiguration(new FluentPublisherConfig());
	modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
	modelBuilder.ApplyConfiguration(new FluentBookAuthorMapConfig());
   	```

[Back to Top](#codingwiki-project) :arrow_up:

----
### EF Core in Console Project

The **CodingWiki_Console** project in this application works with data annotation models.

**Database Helper Methods**
*	In the **Program** file, create a new instance of **ApplicationDbContext**.
*	On the database context object, methods are provided for working with database and migrations. Below are a few examples.

|  |  |
| --- | --- |
| EnsureCreated() | If the database does not exist, then it is created and the Entity Framework model is used to create the database schema. No action is taken if database and tables exist. |
| GetPendingMigrations() | Retrieves all migrations that have not been applied to the database. |
| Migrate() | Applies all pending migrations to the database. |

**Logging Queries**
*	To log executed queries on console app, add the following `LogTo()` method to the ApplicationDbContext class.
*	```csharp
	optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;")
	    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
  	```

**Using LINQ**
*	Get the first Book record.
	```csharp
	Book book = context.Books.FirstOrDefault();
  	```
*	Get the first Book record that satisfies a query condition.
	```csharp
	var input = "Cookie Jar";
	var book = context.Books.FirstOrDefault(u => u.Title == input);
  	```
*	Get a Book record that has a specific primary key value.
	```csharp
	var book = context.Books.Find(6);
  	```
*	Get a single Book that satisfy a specific condition.
	```csharp
	var book = context.Books.Single(u => u.ISBN == "123B12");
	var book = context.Books.SingleOrDefault(u => u.Publisher_Id == 66);
 	```
*	Get a list of Books that satisfy a specific condition.
  	```csharp
	var books = context.Books.Where(u => u.Publisher_Id == 3 && u.Price > 10);
   	```
*	Order a list of Books by title, and then by ISBN number.
	```csharp
	var books = context.Books.OrderBy(u => u.Title).ThenByDescending(u => u.ISBN);
 	```
*	Use pagination methods to retrieve a list of two Books and skip the first two records.
  	```csharp
	var books = context.Books.Skip(2).Take(2);
   	```

----
