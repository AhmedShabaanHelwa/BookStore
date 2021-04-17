using BookStore.Domain.Requests.Author;
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
    public class AuhtorController : ControllerBase
    {
        const string _controllerName = "author/";
        private readonly IAuthorService _authorsService;

        public AuhtorController(IAuthorService authorsService)
        {
            _authorsService = authorsService;
        }

        /// <summary>
        /// Gets all authors - Paginated Form
        /// </summary>
        /// <param name="pageSize">Number of authors per page</param>
        /// <param name="pageIndex">Page number</param>
        /// <returns></returns>
        [HttpGet, Route(AppSettings.ApiVersion + _controllerName)]
        public async Task<IActionResult> GetAuthorsPaginated([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
        {
            var result = await _authorsService.GetAuthorsAsync();
            var totalItems = result.Count();

            var itemsOnPage = result
                .OrderBy(c => c.Name)
                .Skip(pageSize * pageIndex)
                .Take(pageSize);

            var model = new PaginatedResonse<AuthorResponse>(
                pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(result);
        }

        /// <summary>
        /// Gets all authors in non-paginated form
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route(AppSettings.ApiVersion + _controllerName + "all")]
        public async Task<IActionResult> GetAuthors()
        {
            var result = await _authorsService.GetAuthorsAsync();
            if (result != null)
                return Ok(result);
            else
                return NoContent();
        }

        /// <summary>
        /// Gets an author by id
        /// </summary>
        /// <param name="id">Id of an existing author</param>
        /// <returns></returns>
        [HttpGet, Route(AppSettings.ApiVersion + _controllerName + "{id}")]
        public async Task<IActionResult> GetAuthorById([FromRoute] Guid id)
        {
            var result =
                await _authorsService.GetAuthorAsync(new GetAuthorRequest { Id = id });
            if (result != null)
                return Ok(result);
            else
                return NoContent();
        }

        /// <summary>
        /// Gets all books of an author by author's id
        /// </summary>
        /// <param name="id">Id of author</param>
        /// <returns></returns>
        [HttpGet, Route(AppSettings.ApiVersion + _controllerName + "{id}/books")]
        public async Task<IActionResult> GetBooksByAuthorId([FromRoute] Guid id)
        {
            var result =
                await _authorsService.GetBooksByAuthorIdAsync(new GetAuthorRequest { Id = id });
            if (result != null)
                return Ok(result);
            else
                return NoContent();
        }

        /// <summary>
        /// Add (POST) new author to the store
        /// </summary>
        /// <param name="request">Body of added author</param>
        /// <returns></returns>
        [HttpPost, Route(AppSettings.ApiVersion + _controllerName)]
        public async Task<IActionResult> AddAuthor([FromBody] AddAuthorRequest request)
        {
            var result = await _authorsService.AddAuthorAsync(request);
            if (result != null)
            {
                return CreatedAtAction(nameof(GetAuthorById), new { id = result.Id }, null);
            }
            else
            {
                return ValidationProblem("Request contains invalid inputs.");
            }
        }

        /// <summary>
        /// Updates an authors' information by id
        /// </summary>
        /// <param name="request">Body of updated book</param>
        /// <returns></returns>
        [HttpPut, Route(AppSettings.ApiVersion + _controllerName + "{id}")]
        public async Task<IActionResult> UpdateAuthor([FromBody] EditAuthorRequest request)
        {
            var result = await _authorsService.EditAuthorAsync(request);
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
