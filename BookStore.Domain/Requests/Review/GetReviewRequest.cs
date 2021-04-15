using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Requests.Review
{
    public class GetReviewRequest : BaseEntity
    {
        /// <summary>
        /// Review description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Book rate: 0 to 5, and zero indicates no rate.
        /// </summary>
        public int Rating { get; set; }
    }
}
