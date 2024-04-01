using Assesment.Application.DTOs.BookDtos;
using MediatR;

namespace Assesment.Application.Features.Book.Requests.Queries
{
    public class SearchBookRequest : IRequest<BookDto>
    {
        public required string SearchTerm { get; set; }    
    }
}
