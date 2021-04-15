using BookStore.Domain.Entities;
using BookStore.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public IUnitOfWork UnitOfWork => _context;
        private readonly BookContext _context;
        public AuthorRepository(BookContext context)
        {
            _context = context;
        }
        public Author Add(Author author)
        {
            if (author is null) throw new ArgumentNullException("author argument is null");

            return _context.Authors
                .Add(author).Entity;
        }

        public async Task<IEnumerable<Author>> GetAsync()
        {
            return await _context.Authors
                .AsNoTracking()
                .Include(author => author.Books)
                .ToListAsync();
        }

        public async Task<Author> GetAsync(Guid id)
        {
            var author = await _context.Authors
                .FindAsync(id);
            // Check for null
            if (author is null) return null;
            // Set state to detached
            _context.Entry(author).State = EntityState.Detached;

            return author;
        }

        public Author Update(Author author)
        {
            /* returns the entry of the passed item entity 
             * and change the state to modified sothat being effectively
             * saved by UnitOfWork
             */
            if (author is null) throw new ArgumentNullException(nameof(author));
            else
            {
                _context.Entry(author).State = EntityState.Modified;
                return author;
            }
        }
    }
}
