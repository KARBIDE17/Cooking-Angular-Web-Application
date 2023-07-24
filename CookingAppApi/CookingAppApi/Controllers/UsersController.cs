using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CookingAppApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace CookingAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly RecipeDbContext _context;

        public UsersController(RecipeDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetUserId/{id}")]
        public async Task<ActionResult<User>> GetUserId(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);


            return user;
        }

        [HttpGet("GetUserName/{userName}")]
        public async Task<ActionResult<User>> GetUserName(string userName)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(user => user.UserName == userName);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'RecipeDbContext.Users'  is null.");
            }

            if (_context.Users.Any(u => u.UserEmail == user.UserEmail))
            {
                return Conflict("User already exists."); // Return a conflict response indicating that the user already exists
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserId", new { id = user.UserId }, user);
        }

    }
}
