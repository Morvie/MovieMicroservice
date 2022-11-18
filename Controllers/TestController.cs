using Microsoft.AspNetCore.Mvc;

namespace MovieMicroservice.Controllers
{
        
    
    [Route("/")]
    [ApiController]
    public class TestController : Controller
    {
        private readonly IConfiguration _configuration;
        public TestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Index()
        {
            var baseURL = _configuration.GetValue<string>("API:BaseURL");
            var API_key = _configuration.GetValue<string>("API:API_key");
            var url = baseURL + API_key;
            
            return url;
        }
    }
}
