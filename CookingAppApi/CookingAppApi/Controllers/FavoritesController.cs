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
    public class FavoritesController : Controller
    {
        private readonly RecipeDbContext _context;

        public FavoritesController(RecipeDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetFavorite/{id}")]
        public async Task<ActionResult<Favorite>> GetFavorite(int id)
        {
            if (_context.Favorites == null)
            {
                return NotFound();
            }
            var favorite = await _context.Favorites.FindAsync(id);

            if (favorite == null)
            {
                return NotFound();
            }

            return favorite;
        }

        [HttpGet("GetUserFavorites/{UserId:int}")]
        public async Task<ActionResult<List<Favorite>>> GetUserFavorites(int UserId)
        {
            if (_context.Favorites == null)
            {
                return NotFound();
            }
            var favorite = await _context.Favorites.Where(f => f.UserId == UserId).ToListAsync();
            if (favorite == null)
            {
                return NotFound();
            }
            return favorite;
        }

        [HttpPost("AddFavorite")]
        public async Task<ActionResult<Favorite>> PostFavorite(Favorite favorite)
        {
            if (_context.Favorites == null)
            {
                return Problem("Entity set 'UpMeetEventDbContext.Favorites'  is null.");
            }
            _context.Favorites.Add(favorite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavorite", new { id = favorite.UserId }, favorite);
        }

        // DELETE: api/Favorites/5
        [HttpDelete("DeleteFavorite/{id}")]
        public async Task<IActionResult> DeleteFavorite(int id)
        {
            if (_context.Favorites == null)
            {
                return NotFound();
            }
            var favorite = await _context.Favorites.FindAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }

            _context.Favorites.Remove(favorite);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
