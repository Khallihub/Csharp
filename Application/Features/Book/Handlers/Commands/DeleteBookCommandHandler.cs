using Application.Exceptions;
using Assesment.Application.Contracts.Persistence;
using Assesment.Application.Features.Book.Requests.Commands;
using MediatR;

namespace Assesment.Application.Features.Book.Handlers.Commands
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IBookRepository _BookRepository;

        public DeleteBookCommandHandler(IBookRepository  BookRepository)
        {
            _BookRepository = BookRepository;       
        }
        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var result = await _BookRepository.GetById(request.Id);

            if (result == null)
            {
                throw new NotFoundException(nameof(result), request.Id);
            }

            await _BookRepository.Delete(result);

            return Unit.Value;
        }
    }
}
