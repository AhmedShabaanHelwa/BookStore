using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Infrastructure.SchemaDefintions
{
    public class CategoriesSchema : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            /* 1 - Define the table */
            builder.ToTable<Category>("Categories", BookContext.DEFAULT_SCHEMA);
            /* 2 - Set the primary key of the table */
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("NEWID()");
            /* 3 - Seeding with some initial data */
            builder.HasData(
                new Category 
                {
                    Id = Guid.NewGuid(),
                    Name = ".NET"
                },
                new Category 
                {
                    Id = Guid.NewGuid(),
                    Name = "Database"
                }
                ,
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Web development"
                }
                ,
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Algorithms"
                }
                );

            /* 3 - Set properties' (columns') constraints */
            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
