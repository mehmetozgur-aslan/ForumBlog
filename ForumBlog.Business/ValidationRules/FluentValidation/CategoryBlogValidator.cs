using FluentValidation;
using ForumBlog.DTO.DTOs.CategoryBlogDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForumBlog.Business.ValidationRules.FluentValidation
{
    public class CategoryBlogValidator : AbstractValidator<CategoryBlogDto>
    {
        public CategoryBlogValidator()
        {
            RuleFor(x => x.CategoryId).InclusiveBetween(0, int.MaxValue).WithMessage("CategoryId boş geçilemez.");
            RuleFor(x => x.BlogId).InclusiveBetween(0, int.MaxValue).WithMessage("BlogId boş geçilemez.");
        }
    }
}
