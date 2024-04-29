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
    public class FluentPublisherConfig : IEntityTypeConfiguration<Fluent_Publisher>
    {
        public void Configure(EntityTypeBuilder<Fluent_Publisher> modelBuilder)
        {
            // table name
            modelBuilder.ToTable("Fluent_Publishers");

            // primary key
            modelBuilder.HasKey(u => u.Publisher_Id);

            // other validations
            modelBuilder.Property(u => u.Name).IsRequired();
        }
    }
}
