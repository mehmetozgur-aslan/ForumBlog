using FluentValidation;
using ForumBlog.DTO.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForumBlog.Business.ValidationRules.FluentValidation
{
    public class CategoryAddValidator : AbstractValidator<CategoryAddDto>
    {
        public CategoryAddValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez.");
        }
    }
}
