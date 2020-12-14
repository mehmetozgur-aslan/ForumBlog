using ForumBlog.Business.Interface;
using ForumBlog.DataAccess.Interface;
using ForumBlog.DTO.DTOs.CategoryBlogDtos;
using ForumBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForumBlog.Business.Concrete
{
    public class BlogManager : GenericManager<Blog>, IBlogService
    {
        private readonly IGenericDal<Blog> _genericDal;
        private readonly IGenericDal<CategoryBlog> _categoryBlogService;
        private readonly IBlogDal _blogDal;
        public BlogManager(IGenericDal<Blog> genericDal, IGenericDal<CategoryBlog> categoryBlogService, IBlogDal blogDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _categoryBlogService = categoryBlogService;
            _blogDal = blogDal;
        }

        public async Task AddToCategoryAsync(CategoryBlogDto categoryBlogDto)
        {
            var categoryBlog = await _categoryBlogService.GetAsync(x => x.CategoryId == categoryBlogDto.CategoryId && x.BlogId == categoryBlogDto.BlogId);

            if (categoryBlog == null)
            {
                await _categoryBlogService.AddAsync(new CategoryBlog
                {
                    BlogId = categoryBlogDto.BlogId,
                    CategoryId = categoryBlogDto.CategoryId
                });
            }
        }

        public async Task<List<Blog>> GetAllByCategoryIdAsync(int categoryId)
        {
            return await _blogDal.GetAllByCategoryId(categoryId);
        }

        public async Task<List<Blog>> GetAllSortedByPostedTimeAsync()
        {
            return await _genericDal.GetAllAsync(I => I.PostedTime);
        }

        public async Task<List<Category>> GetCategoriesAsync(int blogId)
        {
            return await _blogDal.GetCategoriesAsync(blogId);
        }

        public async Task<List<Blog>> GetLastFiveAsync()
        {
            return await _blogDal.GetLastFiveAsync();
        }

        public async Task RemoveFromCategoryAsync(CategoryBlogDto categoryBlogDto)
        {
            var categoryBlog = await _categoryBlogService.GetAsync(x => x.CategoryId == categoryBlogDto.CategoryId && x.BlogId == categoryBlogDto.BlogId);

            if (categoryBlog != null)
            {
                await _categoryBlogService.RemoveAsync(categoryBlog);
            }
        }
    }
}
