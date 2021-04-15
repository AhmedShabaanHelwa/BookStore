using BookStore.Domain.Requests.Author;
using BookStore.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorResponse>> GetAuthorsAsync();
        Task<AuthorResponse> GetAuthorAsync(GetAuthorRequest request);
        Task<AuthorResponse> AddAuthorAsync(AddAuthorRequest request);
        Task<AuthorResponse> EditAuthorAsync(EditAuthorRequest request);
        Task<IEnumerable<BookResponse>> GetBooksByAuthorIdAsync(GetAuthorRequest request);
    }
}
