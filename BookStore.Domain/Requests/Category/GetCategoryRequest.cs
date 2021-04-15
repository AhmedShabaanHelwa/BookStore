using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Requests.Category
{
    public class GetCategoryRequest : BaseEntity
    {
        /// <summary>
        /// Book category
        /// </summary>
        public string Name { get; set; }
    }
}
