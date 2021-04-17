using BookStore.Domain.Entities;
using BookStore.Domain.Mappers;
using BookStore.Domain.Repository;
using BookStore.Domain.Requests.Category;
using BookStore.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryMapper _categoryMapper;
        private readonly IBookMapper _bookMapper;
        private readonly IBooksRepository _bookRepository;
        public CategoryService(ICategoryRepository categoryRepository, ICategoryMapper categoryMapper,
            IBooksRepository bookRepository, IBookMapper bookMapper)
        {
            _categoryRepository = categoryRepository;
            _categoryMapper = categoryMapper;
            _bookRepository = bookRepository;
            _bookMapper = bookMapper;
        }
        public async Task<CategoryResponse> AddCategoryAsync(AddCategoryRequest category)
        {
            if (category is null) throw new ArgumentException($"Category is  null");
            // create author entity
            var author = new Category { Name = category.Name };

            var result = _categoryRepository.Add(author);
            await _categoryRepository.UnitOfWork.SaveChangesAsync();
            return _categoryMapper.Map(result);
        }

        public async Task<CategoryResponse> EditCategoryAsync(EditCategoryRequest category)
        {
            var existingRecord = await _categoryRepository.GetAsync(category.Id);
            if (existingRecord == null)
            {
                throw new ArgumentException($"Category with {category.Id}is not present");
            }
            var result = _categoryRepository.Update(existingRecord);
            await _categoryRepository.UnitOfWork.SaveChangesAsync();
            return _categoryMapper.Map(result);
        }

        public async Task<IEnumerable<CategoryResponse>> GetCategoriesAsync()
        {
            var result = await _categoryRepository.GetAsync();
            return result.Select(x => _categoryMapper.Map(x));
        }

        public async Task<CategoryResponse> GetCategoryAsync(GetCategoryRequest category)
        {
            if (category?.Id == null) throw new ArgumentNullException();
            var response = await _categoryRepository.GetAsync(category.Id);
            return _categoryMapper.Map(response);
        }

        public async Task<IEnumerable<BookResponse>> GetBooksByCategoryIdAsync(GetCategoryRequest request)
        {
            if (request?.Id == null) throw new ArgumentNullException();
            var response = await _bookRepository.GetBooksByAuthorIdAsync(request.Id);
            return response.Select(book => _bookMapper.Map(book));
        }
    }
}
