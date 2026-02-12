using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Mansus.Server.Data;
using Mansus.Server.DTOs.Author;
using Mansus.Server.Mappers;
using Mansus.Server.Models;


namespace Mansus.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorsController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _context.Authors.ToListAsync();

            var authorDTOs = authors.ToDTOs();

            return Ok(authorDTOs);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
                return NotFound();

            var authorDTO = author.ToDTO();

            return Ok(authorDTO);
        }

        [HttpPost]
        public async Task<IActionResult> PostAuthor(UpdateAuthorDTO updateAuthorDTO)
        {
            var author = new Author
            {
                Name = updateAuthorDTO.Name
            };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            var authorDTO = author.ToDTO();

            return Ok(authorDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAuthor(int id, UpdateAuthorDTO updateAuthorDTO)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
                return NotFound();

            author.Name = updateAuthorDTO.Name;

            await _context.SaveChangesAsync();

            var authorDTO = author.ToDTO();

            return Ok(authorDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
                return NotFound();

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
