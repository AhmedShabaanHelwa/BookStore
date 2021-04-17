using BookStore.Domain.Requests.Category;
using BookStore.Domain.Responses;
using BookStore.Domain.Services;
using BookStore.Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        const string _controllerName = "category/";
        private readonly ICategoryService _categoriesService;

        public CategoryController(ICategoryService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        /// <summary>
        /// Gets all categories - Paginated Form
        /// </summary>
        /// <param name="pageSize">Number of categories per page</param>
        /// <param name="pageIndex">Page number</param>
        /// <returns></returns>
        [HttpGet, Route(AppSettings.ApiVersion + _controllerName)]
        public async Task<IActionResult> GetCategoriesPaginated([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
        {
            var result = await _categoriesService.GetCategoriesAsync();
            var totalItems = result.Count();

            var itemsOnPage = result
                .OrderBy(c => c.Name)
                .Skip(pageSize * pageIndex)
                .Take(pageSize);

            var model = new PaginatedResonse<CategoryResponse>(
                pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(result);
        }

        /// <summary>
        /// Gets all categories in non-paginated form
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route(AppSettings.ApiVersion + _controllerName + "all")]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _categoriesService.GetCategoriesAsync();
            if (result != null)
                return Ok(result);
            else
                return NoContent();
        }

        /// <summary>
        /// Gets a category by id
        /// </summary>
        /// <param name="id">Id of a category</param>
        /// <returns></returns>
        [HttpGet, Route(AppSettings.ApiVersion + _controllerName + "{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
        {
            var result =
                await _categoriesService.GetCategoryAsync(new GetCategoryRequest { Id = id });
            if (result != null)
                return Ok(result);
            else
                return NoContent();
        }

        /// <summary>
        /// Gets all books of a category by category's id
        /// </summary>
        /// <param name="id">Id of author</param>
        /// <returns></returns>
        [HttpGet, Route(AppSettings.ApiVersion + _controllerName + "{id}/books")]
        public async Task<IActionResult> GetBooksByCategoryId([FromRoute] Guid id)
        {
            var result =
                await _categoriesService.GetBooksByCategoryIdAsync(new GetCategoryRequest { Id = id });
            if (result != null)
                return Ok(result);
            else
                return NoContent();
        }

        /// <summary>
        /// Add (POST) a new category to the store
        /// </summary>
        /// <param name="request">Body of added category</param>
        /// <returns></returns>
        [HttpPost, Route(AppSettings.ApiVersion + _controllerName)]
        public async Task<IActionResult> AddAuthor([FromBody] AddCategoryRequest request)
        {
            var result = await _categoriesService.AddCategoryAsync(request);
            if (result != null)
            {
                return CreatedAtAction(nameof(GetCategoryById), new { id = result.Id }, null);
            }
            else
            {
                return ValidationProblem("Request contains invalid inputs.");
            }
        }

        /// <summary>
        /// Updates a category' information by id
        /// </summary>
        /// <param name="request">Body of updated category</param>
        /// <returns></returns>
        [HttpPut, Route(AppSettings.ApiVersion + _controllerName + "{id}")]
        public async Task<IActionResult> UpdateAuthor([FromBody] EditCategoryRequest request)
        {
            var result = await _categoriesService.EditCategoryAsync(request);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return ValidationProblem("Request contains invalid contnent.");
            }
        }
    }
}
