using Microsoft.AspNetCore.Mvc;

using Mansus.Server.Data;
using Mansus.Server.Models;
using Mansus.Server.DTOs;


namespace Mansus.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _context.Books.ToList();

            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBook(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult PostBook(BookDTO bookDTO)
        {
            BookCategory? bookCategory = _context.BookCategories.Find(bookDTO.BookCategoryId);

            if (bookCategory == null)
            {
                return NotFound("Book category not found!");
            }

            var book = new Book
            {
                Name = bookDTO.Name,
                Description = bookDTO.Description,
                BookCategory = bookCategory
            };

            _context.Books.Add(book);
            _context.SaveChanges();

            return Ok(book);
        }

        [HttpPut("{id:int}")]
        public IActionResult PutBook(int id, BookDTO bookDTO)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            book.Name = bookDTO.Name;
            book.Description = bookDTO.Description;

            _context.SaveChanges();

            return Ok(book);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
