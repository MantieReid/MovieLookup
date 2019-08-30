using MovieLookup.Core.Interfaces;
using MovieLookup.Core.Models;
using System.Threading.Tasks;

namespace MovieLookup.Core.Endpoints.Interfaces
{
    internal interface IMoviesEndpoint
    {
        Task<IMovieDbResponse<MovieDetails>> GetMovieDetailsAsync(int movieId, string language = "en-US");
    }
}
