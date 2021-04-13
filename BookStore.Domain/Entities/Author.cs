using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class Author
    {
        /// <summary>
        /// Id of Author.
        /// </summary>
        public Guid AuthorId { get; set; }
        /// <summary>
        /// Author name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Author nationality.
        /// </summary>
        public string Nationality { get; set; }
        /// <summary>
        /// Reference to the authors books.
        /// </summary>
        public ICollection<Book> Books { get; set; }
    }
}
