using MovieLookup.Core.Endpoints.Interfaces;

namespace MovieLookup.Core.Interfaces
{
    public interface IMovieDbService
    {
        IMoviesEndpoint MoviesEndpoint { get; }
    }
}
