using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookCollectionAPI.Data;
using BookCollectionAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookCollectionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly BookCollectionContext _context;

        public UserController(BookCollectionContext context)
        {
            _context = context;
        }

        // Crear nuevo usuario
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        // Listar todos los usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.Include(u => u.Books).ToListAsync();
        }

        // Editar un usuario
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User updatedUser)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;
            user.Password = updatedUser.Password;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Eliminar un usuario
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}