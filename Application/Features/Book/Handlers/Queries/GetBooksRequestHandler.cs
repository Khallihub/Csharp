using Assesment.Application.Contracts.Persistence;
using Assesment.Application.DTOs.BookDtos;
using Assesment.Application.Features.Book.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Assesment.Application.Features.Book.Handlers.Queries
{
    public class GetBooksRequestHandler : IRequestHandler<GetBooksRequest, List<BookDto>>
    {

        private readonly IBookRepository _BookRepository;
        private readonly IMapper _mapper;

        public GetBooksRequestHandler(IBookRepository BookRepository, IMapper mapper)
        {
            _BookRepository = BookRepository;
            _mapper = mapper;
        }
        public async Task<List<BookDto>> Handle(GetBooksRequest request, CancellationToken cancellationToken)
        {
            var Books = await _BookRepository.GetAll();


            return _mapper.Map<List<BookDto>>(Books);
        }
    }
}
