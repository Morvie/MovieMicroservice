using Microsoft.AspNetCore.Mvc;
using static MovieMicroservice.Models.CreditsModel;

namespace MovieMicroservice.Interface.Service
{
    public interface ICreditsService    
    {
        Task<CastModel?> GetMovieCredits(string type, int id);
    }
}
