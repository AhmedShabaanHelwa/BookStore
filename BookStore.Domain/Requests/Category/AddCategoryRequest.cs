using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Requests.Category
{
    public class AddCategoryRequest
    {
        /// <summary>
        /// Book category
        /// </summary>
        public string Name { get; set; }
    }
}
