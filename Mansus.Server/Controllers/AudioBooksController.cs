using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Mansus.Server.Data;
using Mansus.Server.DTOs.Product.BookPublication.AudioBook;
using Mansus.Server.Mappers;
using Mansus.Server.Models;


namespace Mansus.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AudioBooksController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;
        private readonly int pageSize = 20;

        [HttpGet]
        public async Task<IActionResult> GetAudioBooks(int page=0)
        {
            var audioBooks = await _context.AudioBooks
                .Include(audioBook => audioBook.Book)
                    .ThenInclude(book => book.Authors)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var audioBookDTOs = audioBooks.ToDTOs();

            return Ok(audioBookDTOs);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAudioBook(int id)
        {
            var audioBook = await _context.AudioBooks
                .Include(audioBook => audioBook.Book)
                    .ThenInclude(book => book.Authors)
                .FirstAsync(audioBook => audioBook.Id == id);

            if (audioBook == null)
                return NotFound();

            var audioBookDTO = audioBook.ToDTO();

            return Ok(audioBookDTO);
        }

        [HttpPost]
        public async Task<IActionResult> PostAudioBook(UpdateAudioBookDTO updateAudioBookDTO)
        {
            var book = await _context.Books.FindAsync(updateAudioBookDTO.BookId);
            if (book == null)
                return NotFound("Book not found!");

            var publisher = await _context.Publishers.FindAsync(updateAudioBookDTO.PublisherId);
            if (publisher == null)
                return NotFound("Publisher not found!");

            var language = await _context.Languages.FindAsync(updateAudioBookDTO.LanguageId);
            if (language == null)
                return NotFound("Language not found!");

            var audioBook = new AudioBook
            {
                Name = updateAudioBookDTO.Name,
                Description = updateAudioBookDTO.Description,
                Price = updateAudioBookDTO.Price,
                Discount = updateAudioBookDTO.Discount,
                Book = book,
                Publisher = publisher,
                PublishedAt = updateAudioBookDTO.PublishedAt,
                Language = language,
            };

            _context.AudioBooks.Add(audioBook);
            await _context.SaveChangesAsync();

            var audioBookDTO = audioBook.ToDTO();

            return Ok(audioBookDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAudioBook(int id, UpdateAudioBookDTO updateAudioBookDTO)
        {
            var audioBook = await _context.AudioBooks
                .Include(audioBook => audioBook.Book)
                    .ThenInclude(book => book.Authors)
                .FirstAsync(audioBook => audioBook.Id == id);

            if (audioBook == null)
                return NotFound();

            var book = await _context.Books.FindAsync(updateAudioBookDTO.BookId);
            if (book == null)
                return NotFound("Book not found!");

            var publisher = await _context.Publishers.FindAsync(updateAudioBookDTO.PublisherId);
            if (publisher == null)
                return NotFound("Publisher not found!");

            var language = await _context.Languages.FindAsync(updateAudioBookDTO.LanguageId);
            if (language == null)
                return NotFound("Language not found!");

            audioBook.Name = updateAudioBookDTO.Name;
            audioBook.Description = updateAudioBookDTO.Description;
            audioBook.Price = updateAudioBookDTO.Price;
            audioBook.Discount = updateAudioBookDTO.Discount;
            audioBook.Book = book;
            audioBook.Publisher = publisher;
            audioBook.PublishedAt = updateAudioBookDTO.PublishedAt;
            audioBook.Language = language;

            await _context.SaveChangesAsync();

            var audioBookDTO = audioBook.ToDTO();

            return Ok(audioBookDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAudioBook(int id)
        {
            var audioBook = await _context.AudioBooks.FindAsync(id);
            if (audioBook == null)
                return NotFound();

            _context.AudioBooks.Remove(audioBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
