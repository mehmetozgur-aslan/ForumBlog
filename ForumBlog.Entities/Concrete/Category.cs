using ForumBlog.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForumBlog.Entities.Concrete
{
    public class Category : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CategoryBlog> CategoryBlogs { get; set; }

    }
}
