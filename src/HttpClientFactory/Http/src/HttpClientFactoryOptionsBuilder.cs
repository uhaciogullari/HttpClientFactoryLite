using System;
using System.Net.Http;
using System.Threading;
using HttpClientFactoryLite.Properties;

namespace HttpClientFactoryLite
{
    class HttpClientFactoryOptionsBuilder : IHttpClientFactoryOptionsBuilder
    {
        public HttpClientFactoryOptionsBuilder()
        {
            Options = new HttpClientFactoryOptions();
        }

        public IHttpClientFactoryOptionsBuilder ConfigureHttpClient(Action<HttpClient> configureClient)
        {
            if (configureClient == null)
            {
                throw new ArgumentNullException(nameof(configureClient));
            }

            Options.HttpClientActions.Add(configureClient);
            return this;
        }

        public IHttpClientFactoryOptionsBuilder AddHttpMessageHandler(Func<DelegatingHandler> configureHandler)
        {
            if (configureHandler == null)
            {
                throw new ArgumentNullException(nameof(configureHandler));
            }

            Options.HttpMessageHandlerBuilderActions.Add(b => b.AdditionalHandlers.Add(configureHandler()));
            return this;
        }

        public IHttpClientFactoryOptionsBuilder ConfigurePrimaryHttpMessageHandler(Func<HttpMessageHandler> configureHandler)
        {
            if (configureHandler == null)
            {
                throw new ArgumentNullException(nameof(configureHandler));
            }

            Options.HttpMessageHandlerBuilderActions.Add(b => b.PrimaryHandler = configureHandler());
            return this;
        }

        public IHttpClientFactoryOptionsBuilder ConfigureHttpMessageHandlerBuilder(Action<HttpMessageHandlerBuilder> configureBuilder)
        {
            if (configureBuilder == null)
            {
                throw new ArgumentNullException(nameof(configureBuilder));
            }

            Options.HttpMessageHandlerBuilderActions.Add(configureBuilder);
            return this;
        }

        public IHttpClientFactoryOptionsBuilder SetHandlerLifetime(TimeSpan handlerLifetime)
        {
            if (handlerLifetime != Timeout.InfiniteTimeSpan && handlerLifetime < HttpClientFactoryOptions.MinimumHandlerLifetime)
            {
                throw new ArgumentException(Resources.HandlerLifetime_InvalidValue, nameof(handlerLifetime));
            }

            Options.HandlerLifetime = handlerLifetime;
            return this;
        }

        public HttpClientFactoryOptions Options { get; }
    }
}
