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
    public class ReviewRepository : IReviewRepository
    {
        private readonly BookContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public ReviewRepository(BookContext context)
        {
            _context = context;
        }
        public Review Add(Review review)
        {
            if (review is null) throw new ArgumentNullException("review argument is null");

            return _context.Reviews
                .Add(review).Entity;
        }

        public async Task<IEnumerable<Review>> GetAsync()
        {
            return await _context.Reviews
               .AsNoTracking()
               .Include(review => review.Book)
               .ToListAsync();
        }

        public async Task<Review> GetAsync(Guid id)
        {
            var review = await _context.Reviews
                 .FindAsync(id);
            // Check for null
            if (review is null) return null;
            // Set state to detached
            _context.Entry(review).State = EntityState.Detached;

            return review;
        }

        public async Task<IEnumerable<Review>> GetReviewsByBookIdAsync(Guid id)
        {
            var reviews = await _context.Reviews
               .Where(review => review.BookId == id)
               .Include(rev => rev.Book)
               .ToListAsync();

            return reviews;
        }

        public Review Update(Review review)
        {
            /* returns the entry of the passed item entity 
             * and change the state to modified sothat being effectively
             * saved by UnitOfWork
             */
            if (review is null) throw new ArgumentNullException(nameof(review));
            else
            {
                _context.Entry(review).State = EntityState.Modified;
                return review;
            }
        }
    }
}
