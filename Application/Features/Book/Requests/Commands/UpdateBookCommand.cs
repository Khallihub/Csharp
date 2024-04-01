using Assesment.Application.DTOs.BookDtos;
using MediatR;

namespace Assesment.Application.Features.Book.Requests.Commands
{
    public class UpdateBookCommand : IRequest<Unit>
    {
        public required UpdateBookDto updateBookDto { get; set; }
    }
}
