using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Repository
{
    public interface IAuthorRepository : IRepository
    {
        Task<IEnumerable<Author>> GetAsync();
        Task<Author> GetAsync(Guid id);
        Author Add(Author author);
        Author Update(Author author);
    }
}
