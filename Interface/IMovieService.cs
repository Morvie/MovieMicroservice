using MovieMicroservice.Models;

namespace MovieMicroservice.Interface
{
    public interface IMovieService
    {
        Task<Rootobject> GetMovies(string type);
    }
}
