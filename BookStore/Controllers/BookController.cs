using BookStore.Domain.Entities;
using BookStore.Domain.Repository;
using BookStore.Domain.Requests.Book;
using BookStore.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IBookService _bookService;

        public BookController(IBooksRepository booksRepository, IBookService bookService)
        {
            _booksRepository = booksRepository;
            _bookService = bookService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var result = await _bookService.GetBooksAsync();
            return Ok(result);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetBookById([FromRoute] Guid id)
        {
            var result =  await _bookService.GetBookAsync(new GetBookRequest { Id = id });
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> PostBook(AddBookRequest request)
        {
            var result = await _bookService.AddBookAsync(request);
            return CreatedAtAction(nameof(GetBookById), new { id = result.Id }, null);
        }
    }
}
