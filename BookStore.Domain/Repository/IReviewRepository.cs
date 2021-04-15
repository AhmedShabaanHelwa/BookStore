using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Repository
{
    public interface IReviewRepository : IRepository
    {
        Task<IEnumerable<Review>> GetAsync();
        Task<IEnumerable<Review>> GetReviewsByBookIdAsync(Guid id);
        Task<Review> GetAsync(Guid id);
        Review Add(Review review);
        Review Update(Review review);
    }
}
