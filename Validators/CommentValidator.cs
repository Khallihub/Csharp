using Blog.Entities;
using FluentValidation;

namespace Blog.Validator;

public class CommentValidator : AbstractValidator<Comment>
{
    public CommentValidator()
    {
        RuleFor(x => x.Text).NotEmpty().WithMessage("Text is required");
    }
}