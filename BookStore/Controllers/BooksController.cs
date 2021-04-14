using BookStore.Domain.Entities;
using BookStore.Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("/Books")]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _booksRepository.GetAsync();
        }
        [HttpGet, Route("/Books/{id}")]
        public async Task<Book> GetBooks([FromRoute] Guid id)
        {
            return await _booksRepository.GetAsync(id);
        }
    }
}
