using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Domain.Entities;
using BookStore.Domain.Requests.Category;
using BookStore.Domain.Responses;
namespace BookStore.Domain.Mappers
{
    public interface ICategoryMapper
    {
        CategoryResponse Map(Category request);
        Category Map(EditCategoryRequest category);
    }
}
