using ForumBlog.Business.Concrete;
using ForumBlog.Business.Interface;
using ForumBlog.DataAccess.Concrete.EntityFrameworkCore.Repository;
using ForumBlog.DataAccess.Interface;
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
        }
    }
}
