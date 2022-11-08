using Microsoft.AspNetCore.Mvc;
using MovieMicroservice.Interface.Service;
using MovieMicroservice.Models;
using static MovieMicroservice.Models.CreditsModel;

namespace MovieMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditsController : Controller
    {
        private readonly ICreditsService _context;
        public CreditsController(ICreditsService context)
        {   
            _context = context;
        }

        [HttpGet("movie/{id}")]
        public async Task<ActionResult<List<CastModel>>> GetMovieCredits(int id)
        {
            string type = "movie";
            return Ok(await _context.GetMovieCredits(type,id));
        }


    }
}
