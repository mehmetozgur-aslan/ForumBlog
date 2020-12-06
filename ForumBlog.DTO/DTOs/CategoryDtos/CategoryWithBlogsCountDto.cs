using ForumBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForumBlog.DTO.DTOs.CategoryDtos
{
   public class CategoryWithBlogsCountDto
    {
        public int BlogsCount { get; set; }
        public Category Category { get; set; }

    }
}
