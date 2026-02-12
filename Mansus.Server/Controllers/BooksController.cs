using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Mansus.Server.Data;
using Mansus.Server.DTOs.Book;
using Mansus.Server.Mappers;
using Mansus.Server.Models;


namespace Mansus.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _context.Books.ToListAsync();

            var bookDTOs = books.ToDTOs();

            return Ok(bookDTOs);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            var bookDTO = book.ToDTO();

            return Ok(bookDTO);
        }

        [HttpPost]
        public async Task<IActionResult> PostBook(UpdateBookDTO updateBookDTO)
        {
            BookCategory? bookCategory = await _context.BookCategories.FindAsync(updateBookDTO.BookCategoryId);
            if (bookCategory == null)
                return NotFound("Book category not found!");

            var book = new Book
            {
                Name = updateBookDTO.Name,
                Description = updateBookDTO.Description,
                BookCategory = bookCategory
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            var bookDTO = book.ToDTO();

            return Ok(bookDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutBook(int id, UpdateBookDTO updateBookDTO)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            var bookCategory = await _context.BookCategories.FindAsync(updateBookDTO.BookCategoryId);
            if (bookCategory == null)
                return NotFound("Book category not found!");

            book.Name = updateBookDTO.Name;
            book.Description = updateBookDTO.Description;

            await _context.SaveChangesAsync();

            var bookDTO = book.ToDTO();

            return Ok(bookDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
