using Application.DTOs.BookDtos.Validators;
using Application.Responses;
using Assesment.Application.Contracts.Persistence;
using Assesment.Application.Features.Book.Requests.Commands;
using Assessment.Domain;
using AutoMapper;
using MediatR;

namespace Assesment.Application.Features.Book.Handlers.Commands
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BaseResponse>
    {
        private readonly IBookRepository _BookRepository;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IBookRepository BookRepository, IMapper mapper)
        {
            _BookRepository = BookRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseResponse();
            var validator = new CreateBookDtoValidator();
            var validationOutcome = await validator.ValidateAsync(request.CreateBookDto);

            if (!validationOutcome.IsValid)
            {
                response.Success = false;
                response.Message = "Failed to create a new Book :(";
                response.Errors = validationOutcome.Errors.Select(error => error.ErrorMessage).ToList();
            }

            var book = _mapper.Map<Book>(request.CreateBookDto);


            await _BookRepository.Add(book);

            response.Success = true;
            response.Message = "Added a new Book succesfully!";
            response.Id = book.id;

            return response;
        }
    }
}
