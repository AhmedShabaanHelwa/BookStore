using BookStore.Domain.Entities;
using BookStore.Domain.Repository;
using BookStore.Infrastructure.SchemaDefintions;
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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        /// <summary>
        /// Constructor of context class to pass options to the DbContext base class
        /// </summary>
        /// <param name="options">Options of database to be passed to the ORM</param>
        public BookContext(DbContextOptions<BookContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            // Overriden modification: Create configurations of schemas
            builder.ApplyConfiguration(new TenantsSchema());
            builder.ApplyConfiguration(new AuthorsSchema());
            builder.ApplyConfiguration(new ReviewsSchema());
            builder.ApplyConfiguration(new CategoriesSchema());
            builder.ApplyConfiguration(new BooksSchema());

            // Call the base(parent) version of OnModelCreating
            base.OnModelCreating(builder);
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
