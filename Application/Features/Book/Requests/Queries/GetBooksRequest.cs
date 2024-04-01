using Assesment.Application.DTOs.BookDtos;
using MediatR;


namespace Assesment.Application.Features.Book.Requests.Queries
{
    public class GetBooksRequest  : IRequest<List<BookDto>>
    {  
    }
}
