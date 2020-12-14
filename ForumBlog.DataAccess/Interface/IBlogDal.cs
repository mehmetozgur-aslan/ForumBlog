using ForumBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForumBlog.DataAccess.Interface
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        Task<List<Blog>> GetAllByCategoryId(int categoryId);
        Task<List<Category>> GetCategoriesAsync(int blogId);
        Task<List<Blog>> GetLastFiveAsync();
    }
}
