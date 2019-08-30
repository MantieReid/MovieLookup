using MovieLookup.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieLookup.Core
{
    internal class MovieDbRequester : IMovieDbRequester
    {
        private readonly HttpClient _httpClient = new HttpClient() { BaseAddress = new Uri("https://api.themoviedb.org/3/") };

        public async Task<T> SendRequestAsync<T>(HttpRequestMessage httpRequestMessage) where T : class
        {
            var responseMessage = await _httpClient.SendAsync(httpRequestMessage).ConfigureAwait(false);

            return await HandleResponseMessageAsync<T>(responseMessage).ConfigureAwait(false);
        }

        private async Task<T> HandleResponseMessageAsync<T>(HttpResponseMessage httpResponseMessage) where T : class
        {
            using (httpResponseMessage)
            using (var httpContent = httpResponseMessage.Content)
            {
                string contentString = await httpContent.ReadAsStringAsync().ConfigureAwait(false);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(contentString);
                }

                return null;
            }
        }
    }
}