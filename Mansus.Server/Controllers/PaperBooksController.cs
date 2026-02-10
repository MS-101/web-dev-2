using Microsoft.AspNetCore.Mvc;

using Mansus.Server.Data;
using Mansus.Server.Models;
using Mansus.Server.DTOs;


namespace Mansus.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaperBooksController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpGet]
        public IActionResult GetPaperBooks()
        {
            var paperBooks = _context.PaperBooks.ToList();

            return Ok(paperBooks);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPaperBook(int id)
        {
            var paperBook = _context.PaperBooks.Find(id);
            if (paperBook == null)
                return NotFound();

            return Ok(paperBook);
        }

        [HttpPost]
        public IActionResult PostPaperBook(PaperBookDTO paperBookDTO)
        {
            Book? book = _context.Books.Find(paperBookDTO.BookId);
            if (book == null)
                return NotFound("Book not found!");

            Publisher? publisher = _context.Publishers.Find(paperBookDTO.PublisherId);
            if (publisher == null)
                return NotFound("Publisher not found!");

            Language? language = _context.Languages.Find(paperBookDTO.LanguageId);
            if (language == null)
                return NotFound("Language not found!");


            var paperBook = new PaperBook
            {
                Name = paperBookDTO.Name,
                Description = paperBookDTO.Description,
                Price = paperBookDTO.Price,
                Discount = paperBookDTO.Discount,
                Book = book,
                Publisher = publisher,
                PublishedAt = paperBookDTO.PublishedAt,
                Language = language,
            };

            _context.PaperBooks.Add(paperBook);
            _context.SaveChanges();

            return Ok(paperBook);
        }

        [HttpPut("{id:int}")]
        public IActionResult PutPaperBook(int id, PaperBookDTO paperBookDTO)
        {
            var paperBook = _context.PaperBooks.Find(id);
            if (paperBook == null)
                return NotFound();

            Book? book = _context.Books.Find(paperBookDTO.BookId);
            if (book == null)
                return NotFound("Book not found!");

            Publisher? publisher = _context.Publishers.Find(paperBookDTO.PublisherId);
            if (publisher == null)
                return NotFound("Publisher not found!");

            Language? language = _context.Languages.Find(paperBookDTO.LanguageId);
            if (language == null)
                return NotFound("Language not found!");

            paperBook.Name = paperBookDTO.Name;
            paperBook.Description = paperBookDTO.Description;
            paperBook.Price = paperBookDTO.Price;
            paperBook.Discount = paperBookDTO.Discount;
            paperBook.Book = book;
            paperBook.Publisher = publisher;
            paperBook.PublishedAt = paperBookDTO.PublishedAt;
            paperBook.Language = language;

            _context.SaveChanges();

            return Ok(paperBook);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeletePaperBook(int id)
        {
            var paperBook = _context.PaperBooks.Find(id);
            if (paperBook == null)
                return NotFound();

            _context.PaperBooks.Remove(paperBook);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
