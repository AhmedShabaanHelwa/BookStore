using BookStore.Domain.Mappers;
using BookStore.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using BookStore.Domain.Repository;

namespace BookStore.Domain.Extensions
{
    public static class DependenciesRegistration
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services
                .AddSingleton<IBookMapper, BookMapper>()
                .AddSingleton<IAuthorMapper, AuthorMapper>()
                .AddSingleton<IReviewMapper, ReviewMapper>()
                .AddSingleton<ICategoryMapper, CategoryMapper>();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddScoped<IBookService, BookService>()
                .AddScoped<IAuthorService, AuthorService>()
                .AddScoped<IReviewService, ReviewService>()
                .AddScoped<ICategoryService,CategoryService>();
            return services;
        }
        public static IMvcBuilder AddValidation(this IMvcBuilder builder)
        {
            builder
                .AddFluentValidation(configuration =>
                    configuration.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

            return builder;
        }
    }
}
