using Assesment.Application.Contracts.Persistence;
using Assesment.Application.DTOs.BookDtos;
using Assesment.Application.Features.Book.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Assesment.Application.Features.Book.Handlers.Queries
{
    
    public class SearchBookRequestHandler : IRequestHandler<SearchBookRequest, BookDto>
    {

        private readonly IBookRepository _BookRepository;
        private readonly IMapper _mapper;

        public SearchBookRequestHandler(IBookRepository BookRepository, IMapper mapper)
        {
            _BookRepository = BookRepository;
            _mapper = mapper;
        }
        public async Task<BookDto> Handle(SearchBookRequest request, CancellationToken cancellationToken)
        {
            var Book = await _BookRepository.Find(request.SearchTerm);

            return _mapper.Map<BookDto>(Book);
        }
    }
}
