using BookStore.Domain.Requests.Review;
using BookStore.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Services
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewResponse>> GetReviewsAsync();
        Task<ReviewResponse> GetReviewAsync(GetReviewRequest request);
        Task<ReviewResponse> AddReviewAsync(AddReviewRequest request);
        Task<ReviewResponse> EditReviewAsync(EditReviewRequest request);
        Task<IEnumerable<ReviewResponse>> GetReviewsByBookIdAsync(Guid id);
    }
}
