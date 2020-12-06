﻿using AutoMapper;
using ForumBlog.Business.Interface;
using ForumBlog.DTO.DTOs.BlogDtos;
using ForumBlog.DTO.DTOs.CategoryBlogDtos;
using ForumBlog.Entities.Concrete;
using ForumBlog.WebApi.CustomFilters;
using ForumBlog.WebApi.Enums;
using ForumBlog.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ForumBlog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : BaseController
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        public BlogsController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<BlogListDto>>(await _blogService.GetAllSortedByPostedTimeAsync()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<BlogListDto>(await _blogService.FindByIdAsync(id)));
        }

        [HttpPost]
        [Authorize]
        [ValidModel]
        public async Task<IActionResult> Create([FromForm] BlogAddModel blogAddModel)
        {
            var uploadModel = await UploadFileAsync(blogAddModel.Image, "image/jpeg");

            if (uploadModel.UploadState == UploadState.Success)
            {
                blogAddModel.ImagePath = uploadModel.NewName;
            }
            else if (uploadModel.UploadState == UploadState.Error)
            {
                return BadRequest(uploadModel.ErrorMessage);
            }

            await _blogService.AddAsync(_mapper.Map<Blog>(blogAddModel));

            return Created("", blogAddModel);
        }

        [HttpPut("{id}")]
        [Authorize]
        [ValidModel]
        public async Task<IActionResult> Update(int id, [FromForm] BlogUpdateModel blogUpdateModel)
        {
            if (id != blogUpdateModel.Id)
            {
                return BadRequest("geçersiz id");
            }

            var uploadModel = await UploadFileAsync(blogUpdateModel.Image, "image/jpeg");

            if (uploadModel.UploadState == UploadState.Success)
            {
                var blog = await _blogService.FindByIdAsync(blogUpdateModel.Id);
                blog.ShortDescription = blogUpdateModel.ShortDescription;
                blog.Description = blogUpdateModel.Description;
                blog.Title = blogUpdateModel.Title;
                blog.ImagePath = uploadModel.NewName;

                await _blogService.UpdateAsync(blog);
                return NoContent();
            }
            else if (uploadModel.UploadState == UploadState.NotExist)
            {
                var blog = await _blogService.FindByIdAsync(blogUpdateModel.Id);
                blog.ShortDescription = blogUpdateModel.ShortDescription;
                blog.Description = blogUpdateModel.Description;
                blog.Title = blogUpdateModel.Title;

                await _blogService.UpdateAsync(blog);
                return NoContent();
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogService.RemoveAsync(new Blog { Id = id });

            return NoContent();
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> AddToCategory(CategoryBlogDto categoryBlogDto)
        {
            await _blogService.AddToCategoryAsync(categoryBlogDto);
            return Created("",categoryBlogDto);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveFromCategory(CategoryBlogDto categoryBlogDto)
        {
            await _blogService.RemoveFromCategoryAsync(categoryBlogDto);
            return NoContent();
        }

    }
}
