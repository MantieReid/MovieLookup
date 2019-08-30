using MovieLookup.Core.Models;

namespace MovieLookup.Core.Interfaces
{
    public interface IMovieDbResponse<T> where T : class
    {
        bool Success { get; }
        T Response { get; }
        ErrorResponse ErrorResponse { get; }
    }
}
