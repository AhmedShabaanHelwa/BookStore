using BookStore.Domain.Entities;
using BookStore.Domain.Requests.Book;
using BookStore.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Mappers
{
    public interface IBookMapper
    {
        Book Map(AddBookRequest request);
        Book Map(EditBookRequest request);
        BookResponse Map(Book request);
    }
}
