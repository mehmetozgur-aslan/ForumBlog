using FluentValidation;
using ForumBlog.DTO.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForumBlog.Business.ValidationRules.FluentValidation
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(x => x.Id).InclusiveBetween(0, int.MaxValue).WithMessage("Id alanı boş geçilemez.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez.");
        }
    }
}
