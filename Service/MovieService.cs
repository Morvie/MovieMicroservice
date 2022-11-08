using Microsoft.Extensions.Configuration;
using MovieMicroservice.Interface;
using MovieMicroservice.Models;
using System.Net;
using System.Text.Json;
using System.Threading;

namespace MovieMicroservice.Service
{
    public class MovieService:IMovieService
    {
        private readonly IConfiguration _configuration;
        public MovieService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Rootobject?> GetMovies(string type)
        {
            var httpClient = new HttpClient();
            var baseURL = _configuration.GetValue<string>("API:BaseURL");
            var API_key = _configuration.GetValue<string>("API:API_key");
            

            var response = await httpClient.GetAsync(baseURL + "/movie/"+ type +"?api_key=" + API_key);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var jsonData = await response.Content.ReadAsStringAsync();


            Rootobject movieModel = 
                JsonSerializer.Deserialize<Rootobject>(jsonData);

            return movieModel;
        }
    }
}

