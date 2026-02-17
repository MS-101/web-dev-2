using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Mansus.Server.Data;
using Mansus.Server.DTOs.Product.BookPublication.PaperBook;
using Mansus.Server.Mappers;
using Mansus.Server.Models;


namespace Mansus.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaperBooksController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;
        private readonly int pageSize = 20;

        [HttpGet]
        public async Task<IActionResult> GetPaperBooks(int page=0)
        {
            var paperBooks = await _context.PaperBooks
                .Include(paperBook => paperBook.Book)
                    .ThenInclude(book => book.Authors)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var paperBookDTOs = paperBooks.ToDTOs();

            return Ok(paperBookDTOs);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPaperBook(int id)
        {
            var paperBook = await _context.PaperBooks
                .Include(paperBook => paperBook.Book)
                    .ThenInclude(book => book.Authors)
                .FirstAsync(paperBook => paperBook.Id == id);

            if (paperBook == null)
                return NotFound();

            var paperBookDTO = paperBook.ToDTO();

            return Ok(paperBookDTO);
        }

        [HttpPost]
        public async Task<IActionResult> PostPaperBook(UpdatePaperBookDTO updatePaperBookDTO)
        {
            var book = await _context.Books.FindAsync(updatePaperBookDTO.BookId);
            if (book == null)
                return NotFound("Book not found!");

            var publisher = await _context.Publishers.FindAsync(updatePaperBookDTO.PublisherId);
            if (publisher == null)
                return NotFound("Publisher not found!");

            var language = await _context.Languages.FindAsync(updatePaperBookDTO.LanguageId);
            if (language == null)
                return NotFound("Language not found!");

            var paperBook = new PaperBook
            {
                Name = updatePaperBookDTO.Name,
                Description = updatePaperBookDTO.Description,
                Price = updatePaperBookDTO.Price,
                Discount = updatePaperBookDTO.Discount,
                Book = book,
                Publisher = publisher,
                PublishedAt = updatePaperBookDTO.PublishedAt,
                Language = language,
            };

            _context.PaperBooks.Add(paperBook);
            await _context.SaveChangesAsync();

            var paperBookDTO = paperBook.ToDTO();

            return Ok(paperBookDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutPaperBook(int id, UpdatePaperBookDTO updatePaperBookDTO)
        {
            var paperBook = await _context.PaperBooks
                .Include(paperBook => paperBook.Book)
                    .ThenInclude(book => book.Authors)
                .FirstAsync(paperBook => paperBook.Id == id);

            if (paperBook == null)
                return NotFound();

            var book = await _context.Books.FindAsync(updatePaperBookDTO.BookId);
            if (book == null)
                return NotFound("Book not found!");

            var publisher = await _context.Publishers.FindAsync(updatePaperBookDTO.PublisherId);
            if (publisher == null)
                return NotFound("Publisher not found!");

            var language = await _context.Languages.FindAsync(updatePaperBookDTO.LanguageId);
            if (language == null)
                return NotFound("Language not found!");

            paperBook.Name = updatePaperBookDTO.Name;
            paperBook.Description = updatePaperBookDTO.Description;
            paperBook.Price = updatePaperBookDTO.Price;
            paperBook.Discount = updatePaperBookDTO.Discount;
            paperBook.Book = book;
            paperBook.Publisher = publisher;
            paperBook.PublishedAt = updatePaperBookDTO.PublishedAt;
            paperBook.Language = language;

            await _context.SaveChangesAsync();

            var paperBookDTO = paperBook.ToDTO();

            return Ok(paperBookDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePaperBook(int id)
        {
            var paperBook = await _context.PaperBooks.FindAsync(id);
            if (paperBook == null)
                return NotFound();

            _context.PaperBooks.Remove(paperBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
