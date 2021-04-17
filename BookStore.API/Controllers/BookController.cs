using BookStore.Domain.Entities;
using BookStore.Domain.Repository;
using BookStore.Domain.Requests.Book;
using BookStore.Domain.Responses;
using BookStore.Domain.Services;
using BookStore.Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        const string _controllerName = "book/";
        private readonly IBookService _bookService;

        public BookController(IBooksRepository booksRepository, IBookService bookService)
        {
            _bookService = bookService;
        }


        /// <summary>
        /// Gets all books - Paginated Form
        /// </summary>
        /// <param name="pageSize">Number of books per page</param>
        /// <param name="pageIndex">Page number</param>
        /// <returns></returns>
        [HttpGet, Route(AppSettings.ApiVersion+_controllerName)]
        public async Task<IActionResult> GetBooksPaginated([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
        {
            var result = await _bookService.GetBooksAsync();
            var totalItems = result.Count();

            var itemsOnPage = result
                .OrderBy(c => c.Name)
                .Skip(pageSize * pageIndex)
                .Take(pageSize);

            var model = new PaginatedResonse<BookResponse>(
                pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(result);
        }


        /// <summary>
        /// Gets all books - NON paginated form
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route(AppSettings.ApiVersion + _controllerName+"all")]
        public async Task<IActionResult> GetBooks()
        {
            var result = await _bookService.GetBooksAsync();
            return Ok(result);
        }


        /// <summary>
        /// Gets book by its id
        /// </summary>
        /// <param name="id">Book id</param>
        /// <returns></returns>
        [HttpGet, Route(AppSettings.ApiVersion + _controllerName+ "{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] Guid id)
        {
            var result =  await _bookService.GetBookAsync(new GetBookRequest { Id = id });
            return Ok(result);
        }

        /// <summary>
        /// Adds (POST) new book to the store
        /// </summary>
        /// <param name="request">Body of added book</param>
        /// <returns></returns>
        [HttpPost, Route(AppSettings.ApiVersion + _controllerName)]
        public async Task<IActionResult> PostBook(AddBookRequest request)
        {
            var result = await _bookService.AddBookAsync(request);
            if (result != null)
            {
                return CreatedAtAction(nameof(GetBookById), new { id = result.Id }, null);
            }
            else
            {
                return ValidationProblem("Request contains invalid id of Author or category");
            }
        }


        /// <summary>
        /// Updates a book by id
        /// </summary>
        /// <param name="request">Body of updated book</param>
        /// <returns></returns>
        [HttpPut, Route(AppSettings.ApiVersion + _controllerName +"{id}")]
        public async Task<IActionResult> UpdateBook(EditBookRequest request)
        {
            var result = await _bookService.EditBookAsync(request);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return ValidationProblem("Request contains invalid id of Author or category");
            }
        }


        /// <summary>
        /// Soft delete of a book
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete, Route(AppSettings.ApiVersion + "book/{id}")]
        public async Task<ObjectResult> DeleteBook(EditBookRequest request)
        {
            var result = await _bookService.DeleteItemAsync(request);
            if (result != null)
            {
                return StatusCode((int)HttpStatusCode.OK,$"Book with id {request.Id} was deleted successfully");
            }
            else
            {
                return StatusCode((int) HttpStatusCode.NotFound, $"Book with id {request.Id} was not found");
            }
        }
    }
}
