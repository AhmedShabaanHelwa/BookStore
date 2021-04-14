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
        /// Book category
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Book price.
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Book Author.
        /// </summary>
        public virtual Author Author { get; set; }
        /// <summary>
        /// Foriegn key for Authors table.
        /// </summary>
        [ForeignKey("Author")]
        public Guid AuthorId { get; set; }
        /// <summary>
        /// Reference to a list of reviews of the book.
        /// </summary>
        //[JsonProperty(NullValueHandling = NullValueHandling.Include)]
        [JsonIgnore]
        public ICollection<Review> Reviews { set; get; }
    }
}