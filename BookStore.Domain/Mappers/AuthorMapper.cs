using BookStore.Domain.Entities;
using BookStore.Domain.Requests.Author;
using BookStore.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Mappers
{
    public class AuthorMapper : IAuthorMapper
    {
        public AuthorResponse Map(Author author)
        {
            if (author is null) return null;
            return new AuthorResponse
            { 
                Id = author.Id,
                Name = author.Name,
                Nationality = author.Nationality
            };
        }
        public Author Map(EditAuthorRequest author)
        {
            if (author is null) return null;
            return new Author
            {
                Name = author.Name,
                Nationality = author.Nationality
            };
        }
    }
}
