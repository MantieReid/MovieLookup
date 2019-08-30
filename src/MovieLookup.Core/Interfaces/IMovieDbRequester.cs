﻿using System.Net.Http;
using System.Threading.Tasks;

namespace MovieLookup.Core.Interfaces
{
    internal interface IMovieDbRequester
    {
        Task<IMovieDbResponse<T>> SendRequestAsync<T>(HttpRequestMessage httpRequestMessage) where T : class;
    }
}
