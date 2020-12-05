using ForumBlog.DTO.DTOs.AppUserDtos;
using ForumBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForumBlog.Business.Interface
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<AppUser> CheckUser(AppUserLoginDto appUserLoginDto);
    }
}
