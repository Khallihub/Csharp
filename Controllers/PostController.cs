using Blog.Data;
using Blog.Entities;
using Blog.Validator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PostController : Controller
    {
        public static BlogDBContext? _context;

        public PostController(BlogDBContext blogDBContext)
        {
            _context = blogDBContext;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            var validator = new PostValidator();
            var result = validator.Validate(post);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            if (_context == null)
            {
                return NotFound();
            }
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = post.PostId }, post);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (_context == null)
            {
                return NotFound();
            }
            var posts = await _context.Posts.ToListAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (_context == null)
            {
                return NotFound();
            }
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            if (_context == null)
            {
                return NotFound();
            }
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == id);
            if (post == null)
            {
                return NotFound();
            }
            var comments = await _context.Comments.Where(c => c.PostId == id).ToListAsync();
            return Ok(new { post, comments });
        }
        [HttpPatch]
        public async Task<IActionResult> Update(Post post)
        {
            var validator = new PostValidator();
            var result = validator.Validate(post);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            if (_context == null)
            {
                return NotFound();
            }
            var postToUpdate = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == post.PostId);
            if (postToUpdate == null)
            {
                return NotFound();
            }
            postToUpdate.Title = post.Title;
            postToUpdate.Content = post.Content;
            _context.Posts.Update(postToUpdate);
            await _context.SaveChangesAsync();
            return Ok(postToUpdate);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context == null)
            {
                return NotFound();
            }
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.PostId == id);
            if (post == null)
            {
                return NotFound();
            }
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}