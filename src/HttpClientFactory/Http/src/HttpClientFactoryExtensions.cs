using System;
using System.Net.Http;
using Microsoft.Extensions.Internal;

namespace HttpClientFactoryLite
{
    public static class HttpClientFactoryExtensions
    {
        public static HttpClient CreateClient<T>(this IHttpClientFactory httpClientFactory)
        {
            return httpClientFactory.CreateClient(CreateName<T>());
        }

        public static void Register<T>(this IHttpClientFactory httpClientFactory, Action<IHttpClientFactoryOptionsBuilder> configureOptions)
        {
            httpClientFactory.Register(CreateName<T>(), configureOptions);
        }

        private static string CreateName<T>()
        {
            return TypeNameHelper.GetTypeDisplayName(typeof(T), true, true);
        }
    }
}
