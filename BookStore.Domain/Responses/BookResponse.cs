using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Responses
{
    public class BookResponse : BaseEntity
    {
        /// <summary>
        /// Book name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Book price.
        /// </summary>
        public PriceResponse Price { get; set; }
        public CategoryResponse Category { get; set; }
        public Guid CategoryId { get; set; }
        /// <summary>
        /// Book Author.
        /// </summary>
        public AuthorResponse Author { get; set; }
        /// <summary>
        /// Foriegn key for Authors table.
        /// </summary>
        public Guid AuthorId { get; set; }
        /// <summary>
        /// Reference to a list of reviews of the book.
        /// </summary>
        //public ICollection<ReviewResponse> Reviews { set; get; }
        public double AvgRating { set; get; }
    }
}
