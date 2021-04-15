using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Domain.Entities;
using BookStore.Domain.Requests.Author;
using BookStore.Domain.Responses;

namespace BookStore.Domain.Mappers
{
    public interface IAuthorMapper
    {
        AuthorResponse Map(Author request);
        public Author Map(EditAuthorRequest author);
    }
}
