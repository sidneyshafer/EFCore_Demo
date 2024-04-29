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
    public class FluentAuthorConfig : IEntityTypeConfiguration<Fluent_Author>
    {
        public void Configure(EntityTypeBuilder<Fluent_Author> modelBuilder)
        {
            // name of table
            modelBuilder.ToTable("Fluent_Authors");

            // primary key
            modelBuilder.HasKey(u => u.Author_Id);

            // other validations
            modelBuilder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            modelBuilder.Property(u => u.LastName).IsRequired().HasMaxLength(50);
            modelBuilder.Ignore(u => u.FullName);
        }
    }
}
