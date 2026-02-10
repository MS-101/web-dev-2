using Microsoft.AspNetCore.Mvc;

using Mansus.Server.Data;
using Mansus.Server.Models;
using Mansus.Server.DTOs;


namespace Mansus.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EBooksController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpGet]
        public IActionResult GetEBooks()
        {
            var eBooks = _context.EBooks.ToList();

            return Ok(eBooks);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetEBook(int id)
        {
            var eBook = _context.EBooks.Find(id);
            if (eBook == null)
                return NotFound();

            return Ok(eBook);
        }

        [HttpPost]
        public IActionResult PostEBook(EBookDTO eBookDTO)
        {
            Book? book = _context.Books.Find(eBookDTO.BookId);
            if (book == null)
                return NotFound("Book not found!");

            Publisher? publisher = _context.Publishers.Find(eBookDTO.PublisherId);
            if (publisher == null)
                return NotFound("Publisher not found!");

            Language? language = _context.Languages.Find(eBookDTO.LanguageId);
            if (language == null)
                return NotFound("Language not found!");


            var eBook = new EBook
            {
                Name = eBookDTO.Name,
                Description = eBookDTO.Description,
                Price = eBookDTO.Price,
                Discount = eBookDTO.Discount,
                Book = book,
                Publisher = publisher,
                PublishedAt = eBookDTO.PublishedAt,
                Language = language,
            };

            _context.EBooks.Add(eBook);
            _context.SaveChanges();

            return Ok(eBook);
        }

        [HttpPut("{id:int}")]
        public IActionResult PutEBook(int id, EBookDTO eBookDTO)
        {
            var eBook = _context.EBooks.Find(id);
            if (eBook == null)
                return NotFound();

            Book? book = _context.Books.Find(eBookDTO.BookId);
            if (book == null)
                return NotFound("Book not found!");

            Publisher? publisher = _context.Publishers.Find(eBookDTO.PublisherId);
            if (publisher == null)
                return NotFound("Publisher not found!");

            Language? language = _context.Languages.Find(eBookDTO.LanguageId);
            if (language == null)
                return NotFound("Language not found!");

            eBook.Name = eBookDTO.Name;
            eBook.Description = eBookDTO.Description;
            eBook.Price = eBookDTO.Price;
            eBook.Discount = eBookDTO.Discount;
            eBook.Book = book;
            eBook.Publisher = publisher;
            eBook.PublishedAt = eBookDTO.PublishedAt;
            eBook.Language = language;

            _context.SaveChanges();

            return Ok(eBook);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteEBook(int id)
        {
            var eBook = _context.EBooks.Find(id);
            if (eBook == null)
                return NotFound();

            _context.EBooks.Remove(eBook);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
