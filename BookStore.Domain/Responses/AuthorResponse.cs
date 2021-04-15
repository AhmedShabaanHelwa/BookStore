using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Responses
{
    public class AuthorResponse : BaseEntity
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
