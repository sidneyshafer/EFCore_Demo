# CodingWiki Project
* [Entity Framework Core Overview](#entity-framework-core-overview)
* [LINQ Query Methods](#linq-query-methods)
* [Projections](#projections)
* [IQueryable](#iqueryable)
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
* Projection is a way of converting an entity into a C# class with a subset of those properties.

## IQueryable
*	IQueryable interface inherits from IEnumerable.
*	Anything you do with IEnumerable can be done with IQueryable.
*	For example, when using IEnumerable in a query to retrieve a list of filtered records, the records are returned by the database and then filter is applied in memory (on client side). When using IQuerable in a query to retrieve a list of filtered records, the database filters and returns the records.

[Back to Top](#codingwiki-project) :arrow_up:

----
## CodingWiki EF Core Details
* [NuGet Packages](#nuget-packages)
* [Db Context and Migrations](#db-context-and-migrations)
* [Relations](#relations)

### NuGet Packages
*	EF Core NuGet packages used in **CodingWiki_DataAccess** project.
  ```csharp
  Microsoft.EntityFrameworkCore.SQLServer
  Microsoft.EntityFrameworkCore.Tools
  ```
*	NuGet package in **CodingWiki_Web** project.
  ```csharp
 	Microsoft.EntityFrameworkCore.Design
  ```

### Db Context and Migrations

**Add DbContext Class**
*	Create a DbContext class to work with EF Core and interact with database tables.
*	Create the **ApplicationDbContext** class that inherits from DbContext in the **CodingWiki_DataAccess** project.
  ```csharp
  public class ApplicationDbContext : DbContext
  ```
   * DbContext is responsible for providing all the logic needed for working with EF Core (e.g. creating, retrieving, updating, or deleting data from a database).
*	Create DbSet in ApplicationDbContext class.
  ```csharp
  public DbSet<Book> Books { get; set; }
  ```
   * DbSet represents the classes (or models) of the tables we want in our application.

**Configure A Connection String**
*	Override the OnConfiguring method of the DbContext class.
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
*	*Migration files can be found under the project **Migrations** folder.*

**Create Database and Apply Migration**
*	Create a new database and add migration by running `Update-Database` command in the NuGet Package Manager Console.

**Remove Migration**
*	If you have not pushed a migration to the database, you can use the `Remove-Migration` command to remove it.

**Remove a Class/Table from Db**
*Good practice to never remove migration files directly from the Migrations folder in Solution Explorer. Always make changes in the application models or DbContext.*
1. Navigate to application DbContext and remove the previously defined DbSet.
2. Add a new migration (EF Core will see the DbSet has been removed and it will drop table from database).
3. Update the database.

**Rolling Back to Old Migrations**
*	In the Package Manager Console window, update the database followed by the name of migration you want to roll back too.
  ```csharp
  Update-Database AddCategoryToDb
  ```
*	Used for development (not production). Tables/data may be deleted with migration roll back.
*	To revert to the latest migration version, run the `Update-Database` command.

----
### Relations
