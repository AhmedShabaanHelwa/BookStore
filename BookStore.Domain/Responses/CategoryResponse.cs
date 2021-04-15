using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Responses
{
    public class CategoryResponse : BaseEntity
    {
        /// <summary>
        /// Book category
        /// </summary>
        public string Name { get; set; }
    }
}
