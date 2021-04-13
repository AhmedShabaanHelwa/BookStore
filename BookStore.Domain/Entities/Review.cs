using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class Review
    {
        /// <summary>
        /// Id of review.
        /// </summary>
        public Guid ReviewId { get; set; }
        /// <summary>
        /// Review description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Book rate: 0 to 5, and zero indicates no rate.
        /// </summary>
        public int Rating { get; set; }
        /// <summary>
        /// Foriegn key for Books table.
        /// </summary>
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
