using Application.Responses;
using Assesment.Application.DTOs.BookDtos;
using MediatR;

namespace Assesment.Application.Features.Book.Requests.Commands
{
    public class CreateBookCommand : IRequest<BaseResponse>
    {
        public required CreateBookDto CreateBookDto { get; set; }
    }
}
