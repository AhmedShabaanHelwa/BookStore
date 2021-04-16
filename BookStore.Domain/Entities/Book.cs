using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStore.Domain.Entities
{
    public class Book : BaseEntity
    {
        /// <summary>
        /// Book name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Book price.
        /// </summary>
        public Price Price { get; set; }
        public Category Category {get; set;}
        public Guid CategoryId { get; set; }
        /// <summary>
        /// Book Author.
        /// </summary>
        public virtual Author Author { get; set; }
        /// <summary>
        /// Foriegn key for Authors table.
        /// </summary>
        public Guid AuthorId { get; set; }
        /// <summary>
        /// Reference to a list of reviews of the book.
        /// </summary>
        public ICollection<Review> Reviews { set; get; }
        public bool IsInactive { get; set; }
        public Guid TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}