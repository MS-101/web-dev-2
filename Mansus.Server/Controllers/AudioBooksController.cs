using Microsoft.AspNetCore.Mvc;

using Mansus.Server.Data;
using Mansus.Server.Models;
using Mansus.Server.DTOs;


namespace Mansus.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AudioBooksController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpGet]
        public IActionResult GetAudioBooks()
        {
            var audioBooks = _context.AudioBooks.ToList();

            return Ok(audioBooks);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAudioBook(int id)
        {
            var audioBook = _context.AudioBooks.Find(id);
            if (audioBook == null)
                return NotFound();

            return Ok(audioBook);
        }

        [HttpPost]
        public IActionResult PostAudioBook(AudioBookDTO audioBookDTO)
        {
            Book? book = _context.Books.Find(audioBookDTO.BookId);
            if (book == null)
                return NotFound("Book not found!");

            Publisher? publisher = _context.Publishers.Find(audioBookDTO.PublisherId);
            if (publisher == null)
                return NotFound("Publisher not found!");

            Language? language = _context.Languages.Find(audioBookDTO.LanguageId);
            if (language == null)
                return NotFound("Language not found!");


            var audioBook = new AudioBook
            {
                Name = audioBookDTO.Name,
                Description = audioBookDTO.Description,
                Price = audioBookDTO.Price,
                Discount = audioBookDTO.Discount,
                Book = book,
                Publisher = publisher,
                PublishedAt = audioBookDTO.PublishedAt,
                Language = language,
            };

            _context.AudioBooks.Add(audioBook);
            _context.SaveChanges();

            return Ok(audioBook);
        }

        [HttpPut("{id:int}")]
        public IActionResult PutAudioBook(int id, AudioBookDTO audioBookDTO)
        {
            var audioBook = _context.AudioBooks.Find(id);
            if (audioBook == null)
                return NotFound();

            Book? book = _context.Books.Find(audioBookDTO.BookId);
            if (book == null)
                return NotFound("Book not found!");

            Publisher? publisher = _context.Publishers.Find(audioBookDTO.PublisherId);
            if (publisher == null)
                return NotFound("Publisher not found!");

            Language? language = _context.Languages.Find(audioBookDTO.LanguageId);
            if (language == null)
                return NotFound("Language not found!");

            audioBook.Name = audioBookDTO.Name;
            audioBook.Description = audioBookDTO.Description;
            audioBook.Price = audioBookDTO.Price;
            audioBook.Discount = audioBookDTO.Discount;
            audioBook.Book = book;
            audioBook.Publisher = publisher;
            audioBook.PublishedAt = audioBookDTO.PublishedAt;
            audioBook.Language = language;

            _context.SaveChanges();

            return Ok(audioBook);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteAudioBook(int id)
        {
            var audioBook = _context.AudioBooks.Find(id);
            if (audioBook == null)
                return NotFound();

            _context.AudioBooks.Remove(audioBook);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
