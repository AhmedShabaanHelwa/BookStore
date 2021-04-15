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
    public class CategoryRepository : ICategoryRepository
    {
        public IUnitOfWork UnitOfWork => _context;
        private readonly BookContext _context;
        public CategoryRepository(BookContext context)
        {
            _context = context;
        }

        public Category Add(Category category)
        {
            if(category is null) throw new ArgumentNullException("Category is null");
            
            return _context.Categories
                .Add(category).Entity;
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await _context.Categories
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task<Category> GetAsync(Guid id)
        {
            var category = await _context.Categories
                .FindAsync(id);
            // Check for null
            if (category is null) return null;
            // Set state to detached
            _context.Entry(category).State = EntityState.Detached;

            return category;
        }

        public Category Update(Category category)
        {
            /* returns the entry of the passed item entity 
             * and change the state to modified sothat being effectively
             * saved by UnitOfWork
             */
            if (category is null) throw new ArgumentNullException(nameof(category));
            else
            {
                _context.Entry(category).State = EntityState.Modified;
                return category;
            }
        }
    }
}
