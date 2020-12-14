using ForumBlog.DataAccess.Concrete.EntityFrameworkCore.Context;
using ForumBlog.DataAccess.Interface;
using ForumBlog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumBlog.DataAccess.Concrete.EntityFrameworkCore.Repository
{
    public class EfBlogRepository : EfGenericRepository<Blog>, IBlogDal
    {
        public async Task<List<Blog>> GetAllByCategoryId(int categoryId)
        {
            using var context = new ForumBlogContext();

            return await context.Blogs.Join(context.CategoryBlogs, b => b.Id, cb => cb.BlogId, (blog, categoryBlog) => new
            {
                blog = blog,
                categoryBlog = categoryBlog
            }).Where(x => x.categoryBlog.CategoryId == categoryId).Select(x => new Blog
            {
                AppUser = x.blog.AppUser,
                AppUserId = x.blog.AppUserId,
                CategoryBlogs = x.blog.CategoryBlogs,
                Comments = x.blog.Comments,
                Description = x.blog.Description,
                Id = x.blog.Id,
                ImagePath = x.blog.ImagePath,
                PostedTime = x.blog.PostedTime,
                ShortDescription = x.blog.ShortDescription,
                Title = x.blog.Title
            }).ToListAsync();
        }

        public async Task<List<Category>> GetCategoriesAsync(int blogId)
        {
            using var context = new ForumBlogContext();

            return await context.Categories.Join(context.CategoryBlogs, c => c.Id, cb => cb.CategoryId, (category, categoryBlog) => new
            {
                category = category,
                categoryBlog = categoryBlog

            }).Where(x => x.categoryBlog.BlogId == blogId).Select(x => new Category
            {
                Id = x.category.Id,
                Name = x.category.Name
            }).ToListAsync();
        }

    }
}
