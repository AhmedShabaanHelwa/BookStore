using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Requests.Author
{
    public class AddAuthorRequest
    {
        /// <summary>
        /// Author name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Author nationality.
        /// </summary>
        public string Nationality { get; set; }
    }
}
