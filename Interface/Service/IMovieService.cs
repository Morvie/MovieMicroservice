using MovieMicroservice.Models;
using static MovieMicroservice.Models.MovieDetailModel;

namespace MovieMicroservice.Interface.Service
{
    public interface IMovieService
    {
        Task<Rootobject> GetMovies(string type);
        Task<DetailedMovie?> GetMovieDetails(int id);
    }
}
