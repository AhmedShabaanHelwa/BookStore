using BookStore.Domain.Entities;
using BookStore.Domain.Requests.Book;
using BookStore.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Domain.Mappers
{
    public class BookMapper : IBookMapper
    {
        private readonly IAuthorMapper _authorMapper;
        private readonly ICategoryMapper _categoryMapper;
        private readonly IReviewMapper _reviewsMapper;
        private readonly Tenant _tenant;
        public BookMapper(IAuthorMapper authorMapper, ICategoryMapper categoryMapper,
            IReviewMapper reviewsMapper, Tenant tenant)
        {
            _authorMapper = authorMapper;
            _categoryMapper = categoryMapper;
            _reviewsMapper = reviewsMapper;
            _tenant = tenant;
        }

        public Book Map(AddBookRequest request)
        {
            if (request is null) return null;

            var book = new Book
            {
                Name = request.Name,
                AuthorId = request.AuthorId,
                CategoryId = request.CategoryId,
                TenantId = _tenant.Id
            };

            if (request.Price != null)
            {
                book.Price = new Price { Currency = request.Price.Currency, Amount = request.Price.Amount };
            }

            return book;
        }

        public Book Map(EditBookRequest request)
        {
            if (request is null) return null;

            var book = new Book
            {
                Id = request.Id,
                Name = request.Name,
                AuthorId = request.AuthorId,
                CategoryId = request.CategoryId,
            };

            if (request.Price != null)
            {
                book.Price = new Price { Currency = request.Price.Currency, Amount = request.Price.Amount };
            }

            return book;
        }

        public BookResponse Map(Book request)
        {
            if (request is null) return null;

            var response = new BookResponse
            {
                Id = request.Id,
                Name = request.Name,
                Author = _authorMapper.Map(request.Author),
                AuthorId = request.AuthorId,
                Category = _categoryMapper.Map(request.Category),
                CategoryId = request.CategoryId,
            };

            if (request.Price != null)
            {
                response.Price = new PriceResponse { Currency = request.Price.Currency, Amount = request.Price.Amount };
            }
            if (request.Reviews != null)
            {
                response.AvgRating = calcualateAverageRate(request.Reviews);
            }

            return response;
        }

        private float calcualateAverageRate(ICollection<Review> reviews)
        {
            if (reviews is null) return 0.0F;
            float sum = 0.0F;
            foreach (var review in reviews)
            {

                sum += (float)review?.Rating;
            }
            return sum / reviews.Count();
        }
    }
}
