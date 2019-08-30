using MovieLookup.Core.Endpoints;
using MovieLookup.Core.Endpoints.Interfaces;
using MovieLookup.Core.Interfaces;

namespace MovieLookup.Core
{
    public class MovieDbService : IMovieDbService
    {
        public IMoviesEndpoint MoviesEndpoint { get; }

        public MovieDbService(string apiKey)
        {
            var movieDbRequester = new MovieDbRequester();

            MoviesEndpoint = new MoviesEndpoint(apiKey, movieDbRequester);
        }
    }
}
