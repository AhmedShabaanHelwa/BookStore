using BookStore.Domain.Entities;
using BookStore.Domain.Mappers;
using BookStore.Domain.Repository;
using BookStore.Domain.Requests.Author;
using BookStore.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IAuthorMapper _authorMapper;
        private readonly IBookMapper _bookMapper;
        private readonly IBooksRepository _bookRepository;
        public AuthorService(IAuthorRepository authorRepository, IAuthorMapper authorMapper,
            IBooksRepository bookRepository, IBookMapper bookMapper)
        {
            _authorRepository = authorRepository;
            _authorMapper = authorMapper;
            _bookRepository = bookRepository;
            _bookMapper = bookMapper;
        }
        public async Task<AuthorResponse> AddAuthorAsync(AddAuthorRequest request)
        {
            if(request is null) throw new ArgumentException($"Auhthor is not null");
            // create author entity
            var author = new Author { Name = request.Name, Nationality = request.Nationality };
            
            var result = _authorRepository.Add(author);
            await _authorRepository.UnitOfWork.SaveChangesAsync();
            return _authorMapper.Map(result);
        }

        public async Task<AuthorResponse> EditAuthorAsync(EditAuthorRequest request)
        {
            var existingRecord = await _authorRepository.GetAsync(request.Id);
            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.Id}is not present");
            }

            var entity = _authorMapper.Map(request);
            var result = _authorRepository.Update(entity);
            await _authorRepository.UnitOfWork.SaveChangesAsync();
            return _authorMapper.Map(result);
        }

        public async Task<AuthorResponse> GetAuthorAsync(GetAuthorRequest request)
        {
            if (request?.Id == null) throw new ArgumentNullException();
            var response = await _authorRepository.GetAsync(request.Id);
            return _authorMapper.Map(response);
        }

        public async Task<IEnumerable<AuthorResponse>> GetAuthorsAsync()
        {
            var result = await _authorRepository.GetAsync();
            return result.Select(x => _authorMapper.Map(x));
        }

        public async Task<IEnumerable<BookResponse>> GetBooksByAuthorIdAsync(GetAuthorRequest request)
        {
            if (request?.Id == null) throw new ArgumentNullException();
            var response = await _bookRepository.GetBooksByAuthorIdAsync(request.Id);
            return response.Select(book => _bookMapper.Map(book));
        }
    }
}
