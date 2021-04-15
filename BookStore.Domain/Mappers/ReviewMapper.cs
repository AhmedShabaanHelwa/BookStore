using BookStore.Domain.Entities;
using BookStore.Domain.Requests.Review;
using BookStore.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Mappers
{
    public class ReviewMapper : IReviewMapper
    {
        public ReviewResponse Map(Review review)
        {
            if (review is null) return null;
            
            return new ReviewResponse
            {
                Id = review.Id,
                Description = review.Description,
                AverageRating = review.Rating
            };
        }
        public Review Map(EditReviewRequest review)
        {
            if (review is null) return null;
            return new Review
            {
                Description = review.Description,
                Rating = review.Rating
            };
        }
    }
}
