using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class Category : BaseEntity
    {
        /// <summary>
        /// Book category
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Reference to the authors books.
        /// </summary>
        public ICollection<Book> Books { get; set; }
        public Guid TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
