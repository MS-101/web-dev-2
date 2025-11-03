using Microsoft.AspNetCore.Mvc;

using Mansus.Server.Data;
using Mansus.Server.Models;
using Mansus.Server.DTOs;


namespace Mansus.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorsController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = _context.Authors.ToList();

            return Ok(authors);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAuthor(int id)
        {
            var author = _context.Authors.Find(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost]
        public IActionResult PostAuthor(AuthorDTO authorDTO)
        {
            var author = new Author
            {
                Name = authorDTO.Name
            };

            _context.Authors.Add(author);
            _context.SaveChanges();

            return Ok(author);
        }

        [HttpPut("{id:int}")]
        public IActionResult PutAuthor(int id, AuthorDTO authorDTO)
        {
            var author = _context.Authors.Find(id);

            if (author == null)
            {
                return NotFound();
            }

            author.Name = authorDTO.Name;

            _context.SaveChanges();

            return Ok(author);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteAuthor(int id)
        {
            var author = _context.Authors.Find(id);

            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
