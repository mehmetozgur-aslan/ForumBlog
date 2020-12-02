﻿using ForumBlog.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForumBlog.DTO.DTOs.BlogDtos
{
    public class BlogListDto : IDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime PostedTime { get; set; }
    }
}
