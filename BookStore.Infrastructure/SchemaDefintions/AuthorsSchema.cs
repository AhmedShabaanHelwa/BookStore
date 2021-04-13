using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Infrastructure.SchemaDefintions
{
    public class AuthorsSchema : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            /* 1 - Define the table */
            builder.ToTable<Author>("Authors", BookContext.DEFAULT_SCHEMA);
            /* 2 - Set the primary key of the table */
            builder.HasKey(k => k.AuthorId);
            //builder.Property(p => p.AuthorId);

            /* 3 - Set properties' (columns') constraints */
            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);
            
            builder
                .Property(p => p.Nationality)
                .HasMaxLength(30);
        }
    }
}
