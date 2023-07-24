using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CookingAppApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CookingAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeDbContext _context;

        public RecipeController(RecipeDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetRecipeById/{id}")]
        public async Task<ActionResult<Recipe>> GetRecipeById(int id)
        {
            if (_context.Recipes == null)
            {
                return NotFound();
            }

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                MaxDepth = 32 // Set the maximum depth allowed for serialization
            };

            //  var recipe = await _context.Recipes.FindAsync(id);

            var recipe = await _context.Recipes
        
           .Include(r => r.Instructions)        
           .FirstOrDefaultAsync(r => r.RecipeId == id);


            // return recipe;

            return Content(JsonSerializer.Serialize(recipe, options), "application/json");
        }

        [HttpGet("GetRecipeByName/{recipeName}")]
        public async Task<ActionResult<Recipe>> GetRecipeByName(string recipeName)
        {
            if (_context.Recipes == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FirstOrDefaultAsync(recipe => recipe.Name == recipeName);

            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        [HttpPost]
        
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
            if (_context.Recipes == null)
            {
                return Problem("Entity set 'RecipeDbContext.Recipes' is null.");
            }

            // Check if a record with the same primary key value exists
            if (await _context.Recipes.AnyAsync(r => r.RecipeId == recipe.RecipeId))
            {
                // Generate the next available primary key value
                int nextRecipeId = await _context.Recipes.MaxAsync(r => r.RecipeId) + 1;
                recipe.RecipeId = nextRecipeId;
            }

            foreach (var instruction in recipe.Instructions)
            {
                _context.Entry(instruction).State = EntityState.Detached;
            }

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                MaxDepth = 32 // You can adjust the max depth value if needed
            };

            try
            {
                string json = JsonSerializer.Serialize(recipe, options);
                _context.Recipes.Add(recipe);
                await _context.SaveChangesAsync();
            }

            catch (JsonException ex)
            {
                return BadRequest("Invalid JSON date: " + ex.Message);
            }

            return CreatedAtAction("GetRecipeById", new { id = recipe.RecipeId }, recipe);
        }

        [HttpDelete("DeleteRecipe/{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            if (_context.Favorites == null)
            {
                return NotFound();
            }
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("GetLastRecipe")]
        public async Task<ActionResult<Recipe>> GetLastRecipe()
        {
            var lastRecipe = await _context.Recipes.OrderByDescending(r => r.RecipeId).FirstOrDefaultAsync();
            if (lastRecipe == null)
            {
                return NotFound(); // Or any other appropriate response
            }

            return lastRecipe;
        }

        [HttpGet("GetFavoriteRecipe/{id}")]
        public async Task<ActionResult<List<FavoriteRecipe>>> GetFavoriteRecipe(int id)
        {
            if (_context.FavoriteRecipe == null)
            {
                return NotFound();
            }
            var favorite = await _context.FavoriteRecipe.Where(f => f.UserId == id).ToListAsync();
            if (favorite == null)
            {
                return NotFound();
            }
            return favorite;
        }
    }
}
