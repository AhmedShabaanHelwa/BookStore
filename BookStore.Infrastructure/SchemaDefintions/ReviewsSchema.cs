using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Infrastructure.SchemaDefintions
{
    public class ReviewsSchema : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            /* 1 - Define the table */
            builder.ToTable<Review>("Reviews", BookContext.DEFAULT_SCHEMA);
            /* 2 - Set the primary key of the table */
            //builder.HasKey(k => k.ReviewId);
            //builder.Property(p => p.ReviewId);

            /* 3 - Set properties' (columns') constraints */
            builder.Property(p => p.Description)
                .HasMaxLength(2000);


            /* 4 - Set relationships between tables */
            builder
                .HasOne<Book>(rev => rev.Book)
                .WithMany(book => book.Reviews)
                .HasForeignKey(k => k.BookId);
        }
    }
}
