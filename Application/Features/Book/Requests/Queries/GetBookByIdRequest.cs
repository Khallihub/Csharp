using Assesment.Application.DTOs.BookDtos;
using MediatR;

namespace Assesment.Application.Features.Book.Requests.Queries
{
    public class GetBookByIdRequest : IRequest<BookDto>
    {
        public int Id { get; set; }    
    }
}
