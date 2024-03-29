using Blog.Data;
using Blog.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        public static BlogDBContext? _context;

        public CommentController(BlogDBContext blogDBContext)
        {
            _context = blogDBContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comment comment)
        {
            if (_context == null)
            {
                return NotFound();
            }
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return Created();
        }

        [HttpGet("{PostId}")]
        public async Task<IActionResult> Get(int PostId)
        {
            if (_context == null)
            {
                return NotFound();
            }
            var comments = await _context.Comments.Where(p => p.PostId == PostId).ToListAsync();
            return Ok(comments);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Comment comment)
        {
            if (_context == null)
            {
                return NotFound();
            }
            var commentToUpdate = await _context.Comments.FirstOrDefaultAsync(p => p.CommentId == id);
            if (commentToUpdate == null)
            {
                return NotFound();
            }
            commentToUpdate.Text = comment.Text;
            _context.Comments.Update(commentToUpdate);
            await _context.SaveChangesAsync();
            return Ok(commentToUpdate);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_context == null)
            {
                return NotFound();
            }
            var comment = await _context.Comments.FirstOrDefaultAsync(p => p.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}