using Microsoft.AspNetCore.Mvc;

namespace MovieMicroservice.Controllers
{
    [Route("/")]
    [ApiController]
    public class TestController : Controller
    {
        public string Index()
        {
            return "Hello World!";
        }
    }
}
