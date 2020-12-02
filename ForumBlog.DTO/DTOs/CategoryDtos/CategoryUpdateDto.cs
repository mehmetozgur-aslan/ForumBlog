﻿using ForumBlog.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForumBlog.DTO.DTOs.CategoryDtos
{
    public class CategoryUpdateDto : IDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
