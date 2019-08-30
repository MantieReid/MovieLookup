using MovieLookup.Core.Endpoints.Interfaces;
using MovieLookup.Core.Interfaces;
using MovieLookup.Core.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieLookup.Core.Endpoints
{
    public class MoviesEndpoint : IMoviesEndpoint
    {
        private readonly string _apiKey;
        private readonly IMovieDbRequester _movieDbRequester;

        internal MoviesEndpoint(string apiKey, IMovieDbRequester movieDbRequester)
        {
            _apiKey = apiKey;
            _movieDbRequester = movieDbRequester;
        }

        public async Task<MovieDetails> GetMovieDetailsAsync(int movieId, string language = "en-US")
        {
            string address = $"movie/{movieId}?api_key={_apiKey}&language={language}";

            using (var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, address))
            {
                return await _movieDbRequester.SendRequestAsync<MovieDetails>(httpRequestMessage);
            }
        }
    }
}