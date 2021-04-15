using BookStore.Domain.Entities;
using BookStore.Domain.Requests.Category;
using BookStore.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Mappers
{
    public class CategoryMapper : ICategoryMapper
    {
        public CategoryResponse Map(Category category)
        {
            if (category is null) return null;

            return new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name
            };
        }
        public Category Map(EditCategoryRequest category)
        {
            if (category is null) return null;
            return new Category
            {
                Name = category.Name
            };
        }
    }
}
