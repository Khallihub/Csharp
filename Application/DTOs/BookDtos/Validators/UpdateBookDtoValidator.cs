using Assesment.Application.DTOs.BookDtos;
using Assesment.Application.DTOs.BookDtos.Validators;
using FluentValidation;

namespace Application.DTOs.BookDtos.Validators
{
    public class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookDtoValidator()
        {
            Include(new IBookDtoValidator());
            RuleFor(x => x.bookId)
             .NotNull()
             .WithMessage("Id is required and cannot be null.");
        }
    }
}
