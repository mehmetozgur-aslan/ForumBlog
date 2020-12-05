using ForumBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForumBlog.Business.Tools.JwtTool
{
    public interface IJwtService
    {
        JwtToken GenerateJwt(AppUser appUser);
    }
}
