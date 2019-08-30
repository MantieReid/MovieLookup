using MovieLookup.Core.Interfaces;
using MovieLookup.Core.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieLookup.Core
{
    public class MovieDbRequester : IMovieDbRequester
    {
        private readonly HttpClient _httpClient = new HttpClient() { BaseAddress = new Uri("https://api.themoviedb.org/3/") };

        public async Task<IMovieDbResponse<T>> SendRequestAsync<T>(HttpRequestMessage httpRequestMessage) where T : class
        {
            var responseMessage = await _httpClient.SendAsync(httpRequestMessage).ConfigureAwait(false);

            return await HandleResponseMessageAsync<T>(responseMessage).ConfigureAwait(false);
        }

        private async Task<IMovieDbResponse<T>> HandleResponseMessageAsync<T>(HttpResponseMessage httpResponseMessage) where T : class
        {
            using (httpResponseMessage)
            using (var httpContent = httpResponseMessage.Content)
            {
                string contentString = await httpContent.ReadAsStringAsync().ConfigureAwait(false);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var response = JsonConvert.DeserializeObject<T>(contentString);
                    return new MovieDbResponse<T>(response);
                }
                else
                {
                    var statusCode = httpResponseMessage.StatusCode;

                    if (statusCode == HttpStatusCode.Unauthorized || statusCode == HttpStatusCode.NotFound)
                    {
                        var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(contentString);
                        return new MovieDbResponse<T>(errorResponse);
                    }
                }

                return new MovieDbResponse<T>(errorResponse: null);
            }
        }
    }
}