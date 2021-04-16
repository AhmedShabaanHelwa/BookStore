using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Infrastructure.SchemaDefintions
{
    public class TenantsSchema : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            /* 1 - Define the table */
            builder.ToTable<Tenant>("Tenants", BookContext.DEFAULT_SCHEMA);
            /* 2 - Set the primary key of the table */
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("NEWID()");
            builder.HasData(
                new Tenant
                {
                    Id = new Guid("D704C4F3-0EA7-4B2F-8C58-D7D0F10E6416"),
                    Domain = "default.ahmedbookstores.net",
                    Name = "Default landing",
                    Description = "This is the default landing domain for Ahmed bookstores.",
                    // Egypt time
                    CreatedAt = DateTimeOffset.UtcNow.Add(new TimeSpan(2, 0, 0)),
                    UpdatedAt = DateTimeOffset.UtcNow.Add(new TimeSpan(2, 0, 0))
                });

            /* 3 - Set properties' (columns') constraints */
            builder.Property(p => p.Domain)
                .IsRequired()
                .HasMaxLength(800);
            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(600);
        }
    }
}
