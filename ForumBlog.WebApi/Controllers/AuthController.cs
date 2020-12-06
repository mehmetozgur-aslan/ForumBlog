using ForumBlog.Business.Interface;
using ForumBlog.Business.Tools.JwtTool;
using ForumBlog.DTO.DTOs.AppUserDtos;
using ForumBlog.WebApi.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumBlog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IJwtService _jwtService;

        public AuthController(IAppUserService appUserService, IJwtService jwtService)
        {
            _appUserService = appUserService;
            _jwtService = jwtService;
        }

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {

            var user = await _appUserService.CheckUserAsync(appUserLoginDto);

            if (user != null)
            {
                var token = _jwtService.GenerateJwt(user);

                return Created("", token);
            }

            return BadRequest("Kullanıcı adı veya şifre hatalı");
        }


        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
            var user = await _appUserService.FindByNameAsync(User.Identity.Name);

            return Ok(new AppUserDto { Name = user.Name, SurName = user.SurName });
        }

    }
}
