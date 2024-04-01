using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assesment.Application.DTOs.BookDtos;
using Assesment.Application.DTOs.BookDtos.Validators;
using FluentValidation;

namespace Application.DTOs.BookDtos.Validators
{
    public class CreateBookDtoValidator :  AbstractValidator<CreateBookDto>
    {
        public CreateBookDtoValidator()
        {
            Include(new IBookDtoValidator());
        }
    }
}
