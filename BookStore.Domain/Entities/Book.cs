using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class Book
    {
        /// <summary>
        /// Id of a book
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Book name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Book category
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Book price.
        /// </summary>
        public Price Price { get; set; }
        /// <summary>
        /// Book Author.
        /// </summary>
        public Author Author { get; set; }
        /// <summary>
        /// Foriegn key for Authors table.
        /// </summary>
        public Guid AuthorId { get; set; }
        /// <summary>
        /// Reference to a list of reviews of the book.
        /// </summary>
        public ICollection<Review> Reviews { set; get; }
    }
}