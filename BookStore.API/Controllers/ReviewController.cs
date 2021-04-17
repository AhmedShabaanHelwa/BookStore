using BookStore.Domain.Requests.Review;
using BookStore.Domain.Responses;
using BookStore.Domain.Services;
using BookStore.Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        const string _controllerName = "review/";
        private readonly IReviewService _reviewsService;

        public ReviewController(IReviewService reviewsService)
        {
            _reviewsService = reviewsService;
        }

        /// <summary>
        /// Gets all reviews - Paginated Form
        /// </summary>
        /// <param name="pageSize">Number of reviews per page</param>
        /// <param name="pageIndex">Page number</param>
        /// <returns></returns>
        [HttpGet, Route(AppSettings.ApiVersion + _controllerName)]
        public async Task<IActionResult> GetReviewsPaginated([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
        {
            var result = await _reviewsService.GetReviewsAsync();
            var totalItems = result.Count();

            var itemsOnPage = result
                .OrderBy(c => c.AverageRating)
                .Skip(pageSize * pageIndex)
                .Take(pageSize);

            var model = new PaginatedResonse<ReviewResponse>(
                pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(result);
        }

        /// <summary>
        /// Gets all reviews in non-paginated form
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route(AppSettings.ApiVersion + _controllerName + "all")]
        public async Task<IActionResult> GetReviews()
        {
            var result = await _reviewsService.GetReviewsAsync();
            if (result != null)
                return Ok(result);
            else
                return NoContent();
        }

        /// <summary>
        /// Gets a review by id
        /// </summary>
        /// <param name="id">Id of an existing review</param>
        /// <returns></returns>
        [HttpGet, Route(AppSettings.ApiVersion + _controllerName + "{id}")]
        public async Task<IActionResult> GetReviewById([FromRoute] Guid id)
        {
            var result =
                await _reviewsService.GetReviewAsync(new GetReviewRequest { Id = id });
            if (result != null)
                return Ok(result);
            else
                return NoContent();
        }

        /// <summary>
        /// Gets all books of an Review by Review's id
        /// </summary>
        /// <param name="id">Id of Review</param>
        /// <returns></returns>
        [HttpGet, Route(AppSettings.ApiVersion + _controllerName + "book/{id}")]
        public async Task<IActionResult> GetReviewsByBookId([FromRoute] Guid id)
        {
            var result =
                await _reviewsService.GetReviewsByBookIdAsync(id );
            if (result != null)
                return Ok(result);
            else
                return NoContent();
        }

        /// <summary>
        /// Add (POST) new Review to the store
        /// </summary>
        /// <param name="request">Body of added Review</param>
        /// <returns></returns>
        [HttpPost, Route(AppSettings.ApiVersion + _controllerName)]
        public async Task<IActionResult> AddReview([FromBody] AddReviewRequest request)
        {
            var result = await _reviewsService.AddReviewAsync(request);
            if (result != null)
            {
                return CreatedAtAction(nameof(GetReviewById), new { id = result.Id }, null);
            }
            else
            {
                return ValidationProblem("Request contains invalid inputs.");
            }
        }

        /// <summary>
        /// Updates a Review' information by id
        /// </summary>
        /// <param name="request">Body of updated review</param>
        /// <returns></returns>
        [HttpPut, Route(AppSettings.ApiVersion + _controllerName + "{id}")]
        public async Task<IActionResult> UpdateReview([FromBody] EditReviewRequest request)
        {
            var result = await _reviewsService.EditReviewAsync(request);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return ValidationProblem("Request contains invalid contnent.");
            }
        }
    }
}
