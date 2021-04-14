using BookStore.Domain.Entities;
using BookStore.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Infrastructure
{
    public class BookContext : DbContext, IUnitOfWork
    {
        // Constants
        public const string DEFAULT_SCHEMA = "BookStore";

        // Tables
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Review> Reviews { get; set; }


        /// <summary>
        /// Constructor of context class to pass options to the DbContext base class
        /// </summary>
        /// <param name="options">Options of database to be passed to the ORM</param>
        public BookContext(DbContextOptions<BookContext> options) : base (options)
        {

        }
        /*
        protected override void OnModelCreating(ModelBuilder builder) 
        {
            // Overriden modification: Create configurations of schemas
            builder.ApplyConfiguration(new BooksSchema());
            builder.ApplyConfiguration(new AuthorsSchema());
            builder.ApplyConfiguration(new ReviewsSchema());
            // Call the base(parent) version of OnModelCreating
            base.OnModelCreating(builder);
        }
        */

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // passing the options to base class
            base.OnModelCreating(builder);
            builder.Entity<Book>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Author>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<Review>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            //builder.Entity<Price>().Property(p => p.Amount).HasPrecision(2);
        }

        /// <summary>
        /// Effective save of changes in database
        /// </summary>
        /// <param name="cancellationToken">Allows to stop pending async operations</param>
        /// <returns>true or false</returns>
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Calls SaveChangesAsync derived by DbContext class and declared by IUnitOfWork interface.
            await SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
