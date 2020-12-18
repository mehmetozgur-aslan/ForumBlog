using FluentValidation;
using ForumBlog.DTO.DTOs.CommentDtos;
using ForumBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForumBlog.Business.ValidationRules.FluentValidation
{
   public class CommentAddValidator:AbstractValidator<CommentAddDto>
    {
        public CommentAddValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Ad alanı boş geçilemez.");
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Mail alanı boş geçilemez.");
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Açıklama alanı boş geçilemez.");
        }
    }
}
