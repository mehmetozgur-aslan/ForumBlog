﻿using AutoMapper;
using ForumBlog.Business.Interface;
using ForumBlog.Business.Tools.LogTool;
using ForumBlog.DTO.DTOs.CategoryDtos;
using ForumBlog.Entities.Concrete;
using ForumBlog.WebApi.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
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
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly ICustomLogger _customLogger;
        public CategoriesController(ICategoryService categoryService, IMapper mapper, ICustomLogger customLogger)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _customLogger = customLogger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<CategoryListDto>>(await _categoryService.GetAllSortedByIdAsync()));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<CategoryListDto>(await _categoryService.FindByIdAsync(id)));
        }

        [HttpPost]
        [Authorize]
        [ValidModel]
        public async Task<IActionResult> Create([FromForm] CategoryAddDto categoryAddDto)
        {
            await _categoryService.AddAsync(_mapper.Map<Category>(categoryAddDto));
            return Created("", categoryAddDto);
        }

        [HttpPut("{id}")]
        [Authorize]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> Update(int id, [FromForm] CategoryUpdateDto categoryUpdateDto)
        {
            if (id != categoryUpdateDto.Id)
            {
                return BadRequest("geçersiz id");
            }

            await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryUpdateDto));

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.RemoveAsync(await _categoryService.FindByIdAsync(id));

            return NoContent();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetWithBlogsCount()
        {
            var categories = await _categoryService.GetAllWithCategoryBlogsAsync();

            List<CategoryWithBlogsCountDto> listCategory = new List<CategoryWithBlogsCountDto>();

            foreach (var category in categories)
            {
                CategoryWithBlogsCountDto categoryWithBlogsCountDto = new CategoryWithBlogsCountDto();
                categoryWithBlogsCountDto.CategoryId = category.Id;
                categoryWithBlogsCountDto.CategoryName = category.Name;
                categoryWithBlogsCountDto.BlogsCount = category.CategoryBlogs.Count;

                listCategory.Add(categoryWithBlogsCountDto);
            }


            return Ok(listCategory);
        }

        [Route("/Error")]

        public IActionResult Error()
        {
            var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            _customLogger.LogError($"\nHatanın oluştuğu yer:{errorInfo.Path}\n Hata mesajı: {errorInfo.Error.Message}\n Stack Trace : {errorInfo.Error.StackTrace}");

            return Problem("Bir hata oluştu.");
        }
    }
}
