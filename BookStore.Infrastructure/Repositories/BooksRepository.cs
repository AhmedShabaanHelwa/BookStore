using BookStore.Domain.Entities;
using BookStore.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookContext _context;
        private readonly Tenant _tenant;
        public IUnitOfWork UnitOfWork => _context;
        public BooksRepository(BookContext context, Tenant tenant)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _tenant = tenant;
        }

        public async Task<IEnumerable<Book>> GetAsync()
        {
            return await _context.Books
                .Where(t => t.TenantId == _tenant.Id)
                .AsNoTracking()
                .Include(x => x.Author)
                .Include(x => x.Reviews)
                .Include(x => x.Category)
                .ToListAsync();
        }

        public async Task<Book> GetAsync(Guid id)
        {
            var book = await _context.Books
                .Where(t => t.TenantId == _tenant.Id)
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Author)
                .Include(x => x.Reviews)
                .Include(x => x.Category)
                .FirstOrDefaultAsync();
            // Check for null
            if (book is null) return null;
            // Set state to detached
            _context.Entry(book).State = EntityState.Detached;
            return book;
        }

        public async Task<IEnumerable<Review>> GetReviewsByBookIdAsync(Guid id)
        {       
                var book = await _context.Books
                    .Where(t => t.TenantId == _tenant.Id)
                    .FirstOrDefaultAsync(book => book.Id == id);

                return book.Reviews;
        }
        /// <summary>
        /// Adds book to books table in database
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public Book Add(Book book)
        {
            if(book is null) throw new ArgumentNullException(nameof(book));
            else return _context.Add(book).Entity;
        }
        /// <summary>
        /// Updates an existing book in Books table in database
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public Book Update(Book book)
        {
            /* returns the entry of the passed item entity 
             * and change the state to modified sothat being effectively
             * saved by UnitOfWork
             */
            if (book is null) throw new ArgumentNullException(nameof(book));
            else
            {
                _context.Entry(book).State = EntityState.Modified;
                return book;
            }
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(Guid id)
        {
            var books = await _context.Books
                .Where(book => !book.IsInactive)
                .Where(book => book.AuthorId == id)
                .Include(book => book.Author)
                .Include(book => book.Reviews)
                .Include(book => book.Category)
                .ToListAsync();

            return books;
        }

        public async Task<IEnumerable<Book>> GetBooksByCategoryIdAsync(Guid id)
        {
            var books = await _context.Books
                .Where(x => !x.IsInactive)
                .Where(book => book.CategoryId == id)
                .Include(x => x.Author)
                .Include(x => x.Reviews)
                .Include(x => x.Category)
                .ToListAsync();
            return books;
        }
    }
}
