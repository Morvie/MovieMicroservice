using MovieMicroservice.Interface.Service;
using MovieMicroservice.Models;
using System.Text.Json;
using static MovieMicroservice.Models.CreditsModel;

namespace MovieMicroservice.Service
{
    public class CreditsService :ICreditsService
    {
        private readonly IConfiguration _configuration;
        public CreditsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<CastModel?> GetMovieCredits(string type, int id)
        {
            var httpClient = new HttpClient();
            var baseURL = _configuration.GetValue<string>("API:BaseURL");
            var API_key = _configuration.GetValue<string>("API:API_key");

            var response = await httpClient.GetAsync(baseURL + "/" + type + "/" + id +  "/credits" + "?api_key=" + API_key);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var jsonData = await response.Content.ReadAsStringAsync();


            CastModel model =
                JsonSerializer.Deserialize<CastModel>(jsonData);

            return model;
        }
    }
}
