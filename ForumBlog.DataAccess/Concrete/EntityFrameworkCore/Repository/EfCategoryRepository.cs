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
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryDal
    {
        public async Task<List<Category>> GetAllWithCategoryBlogsAsync()
        {
            using var context = new ForumBlogContext();

            return await context.Categories.OrderByDescending(x => x.Id).Include(x => x.CategoryBlogs).ToListAsync();
        }
    }
}
