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
                    Name = ".NET",
                    TenantId = new Guid("D704C4F3-0EA7-4B2F-8C58-D7D0F10E6416")
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Database",
                    TenantId = new Guid("D704C4F3-0EA7-4B2F-8C58-D7D0F10E6416")
                }
                ,
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Web development",
                    TenantId = new Guid("D704C4F3-0EA7-4B2F-8C58-D7D0F10E6416")
                }
                ,
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Algorithms",
                    TenantId = new Guid("D704C4F3-0EA7-4B2F-8C58-D7D0F10E6416")
                }
                );

            /* 3 - Set properties' (columns') constraints */
            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .HasOne(category => category.Tenant)
                .WithMany()
                .HasForeignKey(category => category.TenantId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
