using ForumBlog.DTO.DTOs.CategoryBlogDtos;
using ForumBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForumBlog.Business.Interface
{
    public interface IBlogService : IGenericService<Blog>
    {
        Task<List<Blog>> GetAllSortedByPostedTimeAsync();
        Task AddToCategoryAsync(CategoryBlogDto categoryBlogDto);
        Task RemoveFromCategoryAsync(CategoryBlogDto categoryBlogDto);
        Task<List<Blog>> GetAllByCategoryIdAsync(int categoryId);
        Task<List<Category>> GetCategoriesAsync(int blogId);
        Task<List<Blog>> GetLastFiveAsync();
    }
}
