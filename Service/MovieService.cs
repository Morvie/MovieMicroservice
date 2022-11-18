using MovieMicroservice.Interface.Service;
using MovieMicroservice.Models;
using System.Text.Json;
using static MovieMicroservice.Models.MovieDetailModel;

namespace MovieMicroservice.Service
{
    public class MovieService:IMovieService
    {
        private readonly IConfiguration _configuration;
        public MovieService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Rootobject> GetMovies(string type)
        {
            var httpClient = new HttpClient();
            var baseURL = _configuration.GetSection("API:BaseURL");
            var API_key = _configuration.GetSection("API:API_key");
            var url = baseURL + "/movie/"+ type +"?api_key=" + API_key;

            var response = await httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                System.Console.WriteLine("Cannot get respone from; " + url);  
                return null;
            }
            var jsonData = await response.Content.ReadAsStringAsync();

            Rootobject movieModel = 
                JsonSerializer.Deserialize<Rootobject>(jsonData);

            return movieModel;
        }

        public async Task<DetailedMovie?> GetMovieDetails(int id)
        {
            var httpClient = new HttpClient();
            var baseURL = _configuration.GetValue<string>("API:BaseURL");
            var API_key = _configuration.GetValue<string>("API:API_key");

            var response = await httpClient.GetAsync(baseURL + "/movie/" + id + "?api_key=" + API_key);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var jsonData = await response.Content.ReadAsStringAsync();


            DetailedMovie movieModel = 
                JsonSerializer.Deserialize<DetailedMovie>(jsonData);

            return movieModel;
        }
    }
}

