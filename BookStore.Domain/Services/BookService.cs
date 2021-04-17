using BookStore.Domain.Mappers;
using BookStore.Domain.Repository;
using BookStore.Domain.Requests.Author;
using BookStore.Domain.Requests.Book;
using BookStore.Domain.Requests.Category;
using BookStore.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBooksRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBookMapper _bookMapper;
        public BookService(IBooksRepository bookRepository, IBookMapper bookMapper,
            IAuthorRepository authorRepository, ICategoryRepository categoryRepository)
        {
             _bookRepository = bookRepository;
             _bookMapper = bookMapper;
            _authorRepository = authorRepository;
            _categoryRepository= categoryRepository;
        } 
        public async Task<BookResponse> AddBookAsync(AddBookRequest request)
        {
            // valid author
            if (_authorRepository.GetAsync(request.AuthorId).Result == null) return null;
            // valid category
            if (_categoryRepository.GetAsync(request.CategoryId).Result == null) return null;
            var book = _bookMapper.Map(request);
            var result = _bookRepository.Add(book);
            await _bookRepository.UnitOfWork.SaveChangesAsync();
            return _bookMapper.Map(result);
        }

        public async Task<BookResponse> DeleteItemAsync(EditBookRequest request)
        {
            var existingRecord = await _bookRepository.GetAsync(request.Id);
            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id}is not present");
            }
            else 
            {
                existingRecord.IsInactive = true;
            }

            var result = _bookRepository.Update(existingRecord);
            await _bookRepository.UnitOfWork.SaveChangesAsync();
            return _bookMapper.Map(result);
        }

        public async Task<BookResponse> EditBookAsync(EditBookRequest request)
        {
            var existingRecord = await _bookRepository.GetAsync(request.Id);
            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id}is not present");
            }

            var entity = _bookMapper.Map(request);
            var result = _bookRepository.Update(entity);
            await _bookRepository.UnitOfWork.SaveChangesAsync();
            return _bookMapper.Map(result);
        }

        public async Task<BookResponse> GetBookAsync(GetBookRequest request)
        {
            if (request?.Id == null) throw new ArgumentNullException();
            var response = await _bookRepository.GetAsync(request.Id);
            return _bookMapper.Map(response);
        }

        public async Task<IEnumerable<BookResponse>> GetBooksAsync()
        {
            var result = await _bookRepository.GetAsync();

            return result.Select(x =>  _bookMapper.Map(x));
        }
        
    }
}
