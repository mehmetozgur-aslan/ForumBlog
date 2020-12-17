using AutoMapper;
using ForumBlog.DTO.DTOs.BlogDtos;
using ForumBlog.DTO.DTOs.CategoryDtos;
using ForumBlog.DTO.DTOs.CommentDtos;
using ForumBlog.Entities.Concrete;
using ForumBlog.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumBlog.WebApi.Mapping.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<BlogListDto, Blog>();
            CreateMap<Blog, BlogListDto>();

            CreateMap<BlogUpdateModel, Blog>();
            CreateMap<Blog, BlogUpdateModel>();

            CreateMap<Blog, BlogAddModel>();
            CreateMap<BlogAddModel, Blog>();

            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryAddDto>();

            CreateMap<CategoryListDto, Category>();
            CreateMap<Category, CategoryListDto>();

            CreateMap<Category, CategoryUpdateDto>();
            CreateMap<CategoryUpdateDto, Category>();

            CreateMap<Comment, CommentListDto>();
            CreateMap<CommentListDto, Comment>();
        }
    }
}
