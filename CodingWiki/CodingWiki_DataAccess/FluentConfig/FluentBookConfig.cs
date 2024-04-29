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
    public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            // name of table
            modelBuilder.ToTable("Fluent_Books");

            // primary key
            modelBuilder.HasKey(u => u.Book_Id);

            // other validations
            modelBuilder.Property(u => u.ISBN).IsRequired();
            modelBuilder.Property(u => u.ISBN).HasMaxLength(20); // define property with max length
            modelBuilder.Ignore(u => u.PriceRange); // define property not mapped to Db

            // relations
            // define a one-to-many relation between Book and Publisher
            modelBuilder.HasOne(u => u.Publisher).WithMany(u => u.Books)
                .HasForeignKey(u => u.Publisher_Id);
        }
    }
}
