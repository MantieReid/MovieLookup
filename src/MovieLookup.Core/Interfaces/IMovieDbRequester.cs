using System.Net.Http;
using System.Threading.Tasks;

namespace MovieLookup.Core.Interfaces
{
    internal interface IMovieDbRequester
    {
        Task<T> SendRequestAsync<T>(HttpRequestMessage httpRequestMessage) where T : class;
    }
}
