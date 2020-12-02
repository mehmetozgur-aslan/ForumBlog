using ForumBlog.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForumBlog.DTO.DTOs.AppUserDtos
{
    public class AppUserLoginDto : IDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
