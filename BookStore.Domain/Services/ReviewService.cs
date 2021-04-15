using BookStore.Domain.Entities;
using BookStore.Domain.Mappers;
using BookStore.Domain.Repository;
using BookStore.Domain.Requests.Review;
using BookStore.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IReviewMapper _reviewsMapper;
        private readonly IBooksRepository _bookRepository;
        public ReviewService(IReviewRepository reviewRepository, IReviewMapper reviewMapper,
            IBooksRepository bookRepository)
        {
            _reviewRepository = reviewRepository;
            _reviewsMapper = reviewMapper;
            _bookRepository = bookRepository;
        }
        public async Task<ReviewResponse> AddReviewAsync(AddReviewRequest request)
        {
            if (request is null) throw new ArgumentException($"Review is not null");
            // create review entity
            var review = new Review
            { Description = request.Description, Rating = request.Rating };

            var result = _reviewRepository.Add(review);
            await _reviewRepository.UnitOfWork.SaveChangesAsync();
            return _reviewsMapper.Map(result);
        }

        public async Task<ReviewResponse> EditReviewAsync(EditReviewRequest request)
        {
            var existingRecord = await _reviewRepository.GetAsync(request.Id);
            if (existingRecord == null)
            {
                throw new ArgumentException($"Review with {request.Id}is not present");
            }
            var result = _reviewRepository.Update(existingRecord);
            await _reviewRepository.UnitOfWork.SaveChangesAsync();
            return _reviewsMapper.Map(result);
        }

        public async Task<ReviewResponse> GetReviewAsync(GetReviewRequest request)
        {
            if (request?.Id == null) throw new ArgumentNullException();
            var response = await _reviewRepository.GetAsync(request.Id);
            return _reviewsMapper.Map(response);
        }

        public async Task<IEnumerable<ReviewResponse>> GetReviewsAsync()
        {
            var result = await _reviewRepository.GetAsync();
            return result.Select(x => _reviewsMapper.Map(x));
        }

        public async Task<IEnumerable<ReviewResponse>> GetReviewsByBookIdAsync(Guid id)
        {
            if (id == null) throw new ArgumentNullException();
            var reviews = await _bookRepository.GetReviewsByBookIdAsync(id);
            return reviews.Select(review => _reviewsMapper.Map(review));
        }
    }
}
