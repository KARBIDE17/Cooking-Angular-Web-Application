using CookingAppApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace CookingAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly RecipeService _recipeApiService;

        public HomeController(RecipeService recipeApiService)
        {
            _recipeApiService = recipeApiService;
        }

        [HttpGet("GetRecipe/{name}/{count}")]
        public async Task<ActionResult<Rootobject>> GetRecipe(string name, int count)
        {
            string searchTerm = name;
            return await _recipeApiService.GetRecipe($"?from=0&size={count}&q={searchTerm}");        }

    }
}

