using MovieLookup.Core.Interfaces;
using MovieLookup.Core.Models;

namespace MovieLookup.Core
{
    public class MovieDbResponse<T> : IMovieDbResponse<T> where T : class
    {
        public bool Success { get; }
        public T Response { get; }
        public ErrorResponse ErrorResponse { get; }

        public MovieDbResponse(bool success, T response, ErrorResponse errorResponse)
        {
            Success = success;
            Response = response;
            ErrorResponse = errorResponse;
        }

        public MovieDbResponse(T response) : this(true, response, null)
        {
        }

        public MovieDbResponse(ErrorResponse errorResponse) : this(false, null, errorResponse)
        {
        }
    }
}
