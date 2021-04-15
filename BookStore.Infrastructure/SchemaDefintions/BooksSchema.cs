using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Infrastructure.SchemaDefintions
{
    public class BooksSchema : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
#if (true)
            /* 1 - Define the table */
            builder.ToTable<Book>("Books", BookContext.DEFAULT_SCHEMA);
            /* 2 - Set the primary key of the table */
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("NEWID()");

            /* 3 - Set properties' (columns') constraints */
            // Name column
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            /* 4 - Set relationships between tables */
            // Book - author : One-to-many
            builder
                .HasOne(book => book.Author)
                .WithMany(author => author.Books)
                .HasForeignKey(book => book.AuthorId);
            builder
                .HasOne(book => book.Category)
                .WithMany(author => author.Books)
                .HasForeignKey(book => book.CategoryId);


            /* 5 - Customized conversions */
            builder.Property(p => p.Price)
                .HasConversion(
                // Read from database as 50.36:EUR
                p => $"{p.Amount}:{p.Currency}",
                // Write in database in original form. int Amount and string currency 
                p => new Price
                {
                    Amount = Convert.ToDecimal(p.Split(':', StringSplitOptions.None)[0]),
                    Currency = p.Split(':', StringSplitOptions.None)[1]
                });
        }
#endif
        }
}
