using Assesment.Application.DTOs.BookDtos;
using Assesment.Application.Features.Book.Requests.Commands;
using Assesment.Application.Features.Book.Requests.Queries;
using Assessment.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {

        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<ActionResult<Book>> Get()
        {
            var posts = await _mediator.Send(new GetBooksRequest());
            return Ok(posts);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var post = await _mediator.Send(new GetBookByIdRequest{ Id = id });
            return Ok(post);
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateBookDto Post)
        {
            var command = new CreateBookCommand { CreateBookDto = Post };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] string SearchTerm)
        {
            var command = new SearchBookRequest {SearchTerm = SearchTerm};
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<BooksController>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateBookDto Book)
        {
            var command = new UpdateBookCommand { updateBookDto = Book };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteBookCommand { Id= id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
