using MovieLookup.Core.Interfaces;

namespace MovieLookup.Core
{
    public class MovieDbService : IMovieDbService
    {
        private readonly IMovieDbRequester _movieDbRequester = new MovieDbRequester();

        public MovieDbService()
        {

        }
    }
}
