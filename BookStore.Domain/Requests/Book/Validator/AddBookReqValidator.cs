﻿using BookStore.Domain.Requests.Author;
using BookStore.Domain.Requests.Category;
using BookStore.Domain.Services;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Domain.Requests.Book.Validators
{
    public class AddBookReqValidator : AbstractValidator<AddBookRequest>
    {
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        public AddBookReqValidator(IAuthorService authorService, ICategoryService categoryService)
        {
            /* Dependency registration */
            _authorService = authorService;
            _categoryService = categoryService;

            /* Setting rules */
            RuleFor(x => x.AuthorId)
                .NotEmpty()
                .MustAsync(AuthorExists).WithMessage("Author must exist.");
            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .MustAsync(CategoryExists).WithMessage("Category must exist.");

            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.Price).Must(x => x?.Amount > 0);
            RuleFor(x => x.Name).NotEmpty();
        }

        private async Task<bool> AuthorExists(Guid authorId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(authorId.ToString()))
            {
                return false;
            }

            var author = await _authorService.GetAuthorAsync(new GetAuthorRequest { Id = authorId });
            return author != null;
        }

        private async Task<bool> CategoryExists(Guid categoryId, CancellationToken token)
        {
            if (string.IsNullOrEmpty(categoryId.ToString()))
            {
                return false;
            }

            var category = await _categoryService.GetCategoryAsync(new GetCategoryRequest { Id = categoryId });
            return category != null;
        }
    }
}
