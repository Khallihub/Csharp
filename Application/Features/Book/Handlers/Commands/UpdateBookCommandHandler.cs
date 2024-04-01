using Application.DTOs.BookDtos.Validators;
using Application.Exceptions;
using Assesment.Application.Contracts.Persistence;
using Assesment.Application.Features.Book.Requests.Commands;
using AutoMapper;
using MediatR;

namespace Assesment.Application.Features.Book.Handlers.Commands
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IBookRepository _BookRepository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBookRepository BookRepository, IMapper mapper)
        {
            _BookRepository = BookRepository;
            _mapper = mapper;

        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {

            var validator = new UpdateBookDtoValidator();
            var validationOutcome = await validator.ValidateAsync(request.updateBookDto);

            if (!validationOutcome.IsValid)
            {
                throw new ValidationException(validationOutcome);
            }

            var Book = await _BookRepository.GetById(request.updateBookDto.bookId);


            if (Book == null)
            {
                throw new NotFoundException(nameof(Book), request.updateBookDto.bookId);
            }

            _mapper.Map(request.updateBookDto, Book);

            await _BookRepository.Update(Book);

            return Unit.Value;
        }
    }
}
