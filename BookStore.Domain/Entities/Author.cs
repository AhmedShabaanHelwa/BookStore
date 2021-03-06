using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class Author : BaseEntity
    {
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
        public Guid TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
