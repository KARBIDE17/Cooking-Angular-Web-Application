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
    public class InstructionsController : ControllerBase
    {
        private readonly RecipeDbContext _context;

        public InstructionsController(RecipeDbContext context)
        {
            _context = context;
        }

    } 
}
