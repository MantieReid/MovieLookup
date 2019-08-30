using MovieLookup.Core.Models;
using System.Threading.Tasks;

namespace MovieLookup.Core.Endpoints.Interfaces
{
    internal interface IMoviesEndpoint
    {
        Task<MovieDetails> GetMovieDetailsAsync(int movieId, string language = "en-US");
    }
}
