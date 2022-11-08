using Microsoft.AspNetCore.Mvc;
using MovieMicroservice.Interface;
using MovieMicroservice.Models;
using Nancy;

namespace MovieMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _context;
        public MovieController(IMovieService context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Rootobject>>> GetPopularMovies()
        {
            string type = "popular";
            return Ok(await _context.GetMovies(type));
        }

        [HttpGet]
        public async Task<ActionResult<List<Rootobject>>> GetUpcomingMovies()
        {
            string type = "upcoming";
            return Ok(await _context.GetMovies(type));

        }

    }
 }
