using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Repository
{
    public interface ICategoryRepository : IRepository
    {
        Task<IEnumerable<Category>> GetAsync();
        Task<Category> GetAsync(Guid id);
        Category Add(Category category);
        Category Update(Category category);
    }
}
