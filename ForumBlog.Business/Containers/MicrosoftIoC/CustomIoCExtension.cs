using FluentValidation;
using ForumBlog.Business.Concrete;
using ForumBlog.Business.Interface;
using ForumBlog.Business.Tools.JwtTool;
using ForumBlog.Business.Tools.LogTool;
using ForumBlog.Business.ValidationRules.FluentValidation;
using ForumBlog.DataAccess.Concrete.EntityFrameworkCore.Repository;
using ForumBlog.DataAccess.Interface;
using ForumBlog.DTO.DTOs.AppUserDtos;
using ForumBlog.DTO.DTOs.CategoryBlogDtos;
using ForumBlog.DTO.DTOs.CategoryDtos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForumBlog.Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDepencencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogDal, EfBlogRepository>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();

            services.AddScoped<IJwtService, JwtManager>();

            services.AddScoped<ICustomLogger, NLogAdapter>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginValidator>();
            services.AddTransient<IValidator<CategoryAddDto>, CategoryAddValidator>();
            services.AddTransient<IValidator<CategoryBlogDto>, CategoryBlogValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();
        }
    }
}
