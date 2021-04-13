using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Repository
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Book>> GetAsync();
        Task<Book> GetAsync(Guid id);
        Task<IEnumerable<Review>> GetReviewsByBookIdAsync(Guid id);
        Book Add(Book book);
        Book Update(Book book);
    }
}
