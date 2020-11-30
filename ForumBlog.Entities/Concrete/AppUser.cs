using ForumBlog.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForumBlog.Entities.Concrete
{
    public class AppUser : ITable
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public List<Blog> Blogs { get; set; }

    }
}
