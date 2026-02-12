using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Mansus.Server.Data;
using Mansus.Server.DTOs.Product.BookPublication.EBook;
using Mansus.Server.Mappers;
using Mansus.Server.Models;


namespace Mansus.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EBooksController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpGet]
        public async Task<IActionResult> GetEBooks()
        {
            var eBooks = await _context.EBooks.ToListAsync();

            var eBookDTOs = eBooks.ToDTOs();

            return Ok(eBookDTOs);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEBook(int id)
        {
            var eBook = await _context.EBooks.FindAsync(id);
            if (eBook == null)
                return NotFound();

            var eBookDTO = eBook.ToDTO();

            return Ok(eBookDTO);
        }

        [HttpPost]
        public async Task<IActionResult> PostEBook(UpdateEBookDTO updateEBookDTO)
        {
            var book = await _context.Books.FindAsync(updateEBookDTO.BookId);
            if (book == null)
                return NotFound("Book not found!");

            var publisher = await _context.Publishers.FindAsync(updateEBookDTO.PublisherId);
            if (publisher == null)
                return NotFound("Publisher not found!");

            var language = await _context.Languages.FindAsync(updateEBookDTO.LanguageId);
            if (language == null)
                return NotFound("Language not found!");

            var eBook = new EBook
            {
                Name = updateEBookDTO.Name,
                Description = updateEBookDTO.Description,
                Price = updateEBookDTO.Price,
                Discount = updateEBookDTO.Discount,
                Book = book,
                Publisher = publisher,
                PublishedAt = updateEBookDTO.PublishedAt,
                Language = language,
            };

            _context.EBooks.Add(eBook);
            await _context.SaveChangesAsync();

            var eBookDTO = eBook.ToDTO();

            return Ok(eBookDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutEBook(int id, UpdateEBookDTO updateEBookDTO)
        {
            var eBook = await _context.EBooks.FindAsync(id);
            if (eBook == null)
                return NotFound();

            var book = await _context.Books.FindAsync(updateEBookDTO.BookId);
            if (book == null)
                return NotFound("Book not found!");

            var publisher = await _context.Publishers.FindAsync(updateEBookDTO.PublisherId);
            if (publisher == null)
                return NotFound("Publisher not found!");

            var language = await _context.Languages.FindAsync(updateEBookDTO.LanguageId);
            if (language == null)
                return NotFound("Language not found!");

            eBook.Name = updateEBookDTO.Name;
            eBook.Description = updateEBookDTO.Description;
            eBook.Price = updateEBookDTO.Price;
            eBook.Discount = updateEBookDTO.Discount;
            eBook.Book = book;
            eBook.Publisher = publisher;
            eBook.PublishedAt = updateEBookDTO.PublishedAt;
            eBook.Language = language;

            await _context.SaveChangesAsync();

            var eBookDTO = eBook.ToDTO();

            return Ok(eBookDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEBook(int id)
        {
            var eBook = await _context.EBooks.FindAsync(id);
            if (eBook == null)
                return NotFound();

            _context.EBooks.Remove(eBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
