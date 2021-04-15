using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Requests.Book
{
    public class AddBookRequest
    {
        /// <summary>
        /// Book name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Book price.
        /// </summary>
        public Price Price { get; set; }
        public Guid CategoryId { get; set; }
        /// <summary>
        /// Book Author.
        /// </summary>
        public Guid AuthorId { get; set; }
    }
}
