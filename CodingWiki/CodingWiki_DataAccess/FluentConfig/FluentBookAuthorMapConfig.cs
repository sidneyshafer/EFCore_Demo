using CodingWiki_Model.Models.FluentModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.FluentConfig
{
    public class FluentBookAuthorMapConfig : IEntityTypeConfiguration<Fluent_BookAuthorMap>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookAuthorMap> modelBuilder)
        {
            // table name
            modelBuilder.ToTable("Fluent_BookAuthorMap");

            // primary (composite) key
            modelBuilder.HasKey(u => new { u.Author_Id, u.Book_Id });

            // relations
            // define a many-to-many relation between Book and Author
            modelBuilder
                .HasOne(u => u.Book).WithMany(u => u.Authors)
                .HasForeignKey(u => u.Book_Id);
            modelBuilder
                .HasOne(u => u.Author).WithMany(u => u.Books)
                .HasForeignKey(u => u.Author_Id);
        }
    }
}
