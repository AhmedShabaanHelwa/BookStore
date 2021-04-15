using BookStore.Domain.Entities;
using BookStore.Domain.Requests.Review;
using BookStore.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Mappers
{
    public interface IReviewMapper
    {
        ReviewResponse Map(Review request);
        Review Map(EditReviewRequest review);
    }
}
