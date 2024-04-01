using FluentValidation;

namespace Assesment.Application.DTOs.BookDtos.Validators
{
    public class IBookDtoValidator : AbstractValidator<IBookDto>
    {
        public IBookDtoValidator()
        {
            RuleFor(x => x.title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

            RuleFor(x => x.author)
                .NotEmpty().WithMessage("Author is required.")
                .MaximumLength(100).WithMessage("Author must not exceed 100 characters.");

            RuleFor(x => x.genre)
                .NotEmpty().WithMessage("Genre is required.")
                .MaximumLength(50).WithMessage("Genre must not exceed 50 characters.");

            RuleFor(x => x.dateTime)
                .NotEmpty().WithMessage("Release date is required.")
                .LessThan(DateTime.Now).WithMessage("Release date must be in the past.");
        }
    }
}