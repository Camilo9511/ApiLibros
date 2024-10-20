using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookCollectionAPI.Data;
using BookCollectionAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCollectionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookCollectionContext _context;

        public BookController(BookCollectionContext context)
        {
            _context = context;
        }

        // Crear nuevo libro
        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }

        // Listar todos los libros de un usuario
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks(int userId)
        {
            return await _context.Books.Where(b => b.UserId == userId).ToListAsync();
        }

        // Editar un libro
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book updatedBook)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Year = updatedBook.Year;
            book.CoverImageUrl = updatedBook.CoverImageUrl;
            book.Rating = updatedBook.Rating;
            book.Review = updatedBook.Review;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Eliminar un libro
        [HttpDelete("{id}")]
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