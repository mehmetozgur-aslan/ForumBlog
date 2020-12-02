using ForumBlog.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForumBlog.DTO.DTOs.CategoryDtos
{
    public class CategoryAddDto : IDTO
    {
        public string Name { get; set; }
    }
}
