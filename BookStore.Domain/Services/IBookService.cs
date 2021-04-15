using BookStore.Domain.Requests.Author;
using BookStore.Domain.Requests.Book;
using BookStore.Domain.Requests.Category;
using BookStore.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponse>> GetBooksAsync();
        Task<BookResponse> GetBookAsync(GetBookRequest request);
        Task<BookResponse> AddBookAsync(AddBookRequest request);
        Task<BookResponse> EditBookAsync(EditBookRequest request);
        Task<BookResponse> DeleteItemAsync(EditBookRequest request);
    }
}
