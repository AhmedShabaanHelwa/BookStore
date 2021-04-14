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
        public IUnitOfWork UnitOfWork => _context;
        public BooksRepository(BookContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Book>> GetAsync()
        {
            return await _context.Books
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Book> GetAsync(Guid id)
        {
            var x = await _context.Books
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Include(x => x.Author)
                //.Include(x => x.Reviews)
                .FirstOrDefaultAsync();
            return x;
        }

        public Task<IEnumerable<Review>> GetReviewsByBookIdAsync(Guid id)
        {
            // TODO:
            throw new NotImplementedException();
        }
        /// <summary>
        /// Adds an item to items table in database
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
    }
}
