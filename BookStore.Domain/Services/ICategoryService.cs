using BookStore.Domain.Requests.Category;
using BookStore.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponse>> GetCategoriesAsync();
        Task<CategoryResponse> GetCategoryAsync(GetCategoryRequest request);
        Task<CategoryResponse> AddCategoryAsync(AddCategoryRequest request);
        Task<CategoryResponse> EditCategoryAsync(EditCategoryRequest request);
        Task<IEnumerable<BookResponse>> GetBooksByCategoryIdAsync(GetCategoryRequest request);
    }
}
