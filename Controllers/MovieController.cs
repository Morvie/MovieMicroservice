using Microsoft.AspNetCore.Mvc;
using MovieMicroservice.Interface.Service;
using MovieMicroservice.Models;
using Nancy;
using static MovieMicroservice.Models.MovieDetailModel;

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
        [HttpGet("Popular")]
        public async Task<ActionResult<List<Rootobject>>> GetPopularMovies()
        {
            string type = "popular";
            return Ok(await _context.GetMovies(type));
        }

        [HttpGet("Upcoming")]
        public async Task<ActionResult<List<Rootobject>>> GetUpcomingMovies()
        {
            string type = "upcoming";
            return Ok(await _context.GetMovies(type));
        }

        [HttpGet("details/{id}")]
        public async Task<ActionResult<List<DetailedMovie>>> GetMovieDetails(int id)
        {
            return Ok(await _context.GetMovieDetails(id));
        }

    }
 }
