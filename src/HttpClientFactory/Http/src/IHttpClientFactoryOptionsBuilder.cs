using System;
using System.Net.Http;
using System.Threading;

namespace Microsoft.Extensions.Http
{
    /// <summary>
    /// A builder for configuring named <see cref="HttpClient"/> instances returned by <see cref="IHttpClientFactory"/>.
    /// </summary>
    public interface IHttpClientFactoryOptionsBuilder
    {
        /// <summary>
        /// Adds a delegate that will be used to configure a named <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="configureClient">A delegate that is used to configure an <see cref="HttpClient"/>.</param>
        /// <returns>An <see cref="IHttpClientFactoryOptionsBuilder"/> that can be used to configure the client.</returns>
        IHttpClientFactoryOptionsBuilder ConfigureHttpClient(Action<HttpClient> configureClient);

        /// <summary>
        /// Adds a delegate that will be used to create an additional message handler for a named <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="configureHandler">A delegate that is used to create a <see cref="DelegatingHandler"/>.</param>
        /// <returns>An <see cref="IHttpClientFactoryOptionsBuilder"/> that can be used to configure the client.</returns>
        /// <remarks>
        /// The <see paramref="configureHandler"/> delegate should return a new instance of the message handler each time it
        /// is invoked.
        /// </remarks>
        IHttpClientFactoryOptionsBuilder AddHttpMessageHandler(Func<DelegatingHandler> configureHandler);

        /// <summary>
        /// Adds a delegate that will be used to configure the primary <see cref="HttpMessageHandler"/> for a 
        /// named <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="configureHandler">A delegate that is used to create an <see cref="HttpMessageHandler"/>.</param>
        /// <returns>An <see cref="IHttpClientFactoryOptionsBuilder"/> that can be used to configure the client.</returns>
        /// <remarks>
        /// The <see paramref="configureHandler"/> delegate should return a new instance of the message handler each time it
        /// is invoked.
        /// </remarks>
        IHttpClientFactoryOptionsBuilder ConfigurePrimaryHttpMessageHandler(Func<HttpMessageHandler> configureHandler);

        /// <summary>
        /// Adds a delegate that will be used to configure message handlers using <see cref="HttpMessageHandlerBuilder"/> 
        /// for a named <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="configureBuilder">A delegate that is used to configure an <see cref="HttpMessageHandlerBuilder"/>.</param>
        /// <returns>An <see cref="IHttpClientFactoryOptionsBuilder"/> that can be used to configure the client.</returns>
        IHttpClientFactoryOptionsBuilder ConfigureHttpMessageHandlerBuilder(Action<HttpMessageHandlerBuilder> configureBuilder);

        /// <summary>
        /// Sets the length of time that a <see cref="HttpMessageHandler"/> instance can be reused. Each named 
        /// client can have its own configured handler lifetime value. The default value is two minutes. Set the lifetime to
        /// <see cref="Timeout.InfiniteTimeSpan"/> to disable handler expiry.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The default implementation of <see cref="IHttpClientFactory"/> will pool the <see cref="HttpMessageHandler"/>
        /// instances created by the factory to reduce resource consumption. This setting configures the amount of time
        /// a handler can be pooled before it is scheduled for removal from the pool and disposal.
        /// </para>
        /// <para>
        /// Pooling of handlers is desirable as each handler typically manages its own underlying HTTP connections; creating
        /// more handlers than necessary can result in connection delays. Some handlers also keep connections open indefinitely
        /// which can prevent the handler from reacting to DNS changes. The value of <paramref name="handlerLifetime"/> should be
        /// chosen with an understanding of the application's requirement to respond to changes in the network environment.
        /// </para>
        /// <para>
        /// Expiry of a handler will not immediately dispose the handler. An expired handler is placed in a separate pool 
        /// which is processed at intervals to dispose handlers only when they become unreachable. Using long-lived
        /// <see cref="HttpClient"/> instances will prevent the underlying <see cref="HttpMessageHandler"/> from being
        /// disposed until all references are garbage-collected.
        /// </para>
        /// </remarks>
        IHttpClientFactoryOptionsBuilder SetHandlerLifetime(TimeSpan handlerLifetime);

        /// <summary>
        /// Gets the configured <see cref="HttpClientFactoryOptions"/> 
        /// </summary>
        HttpClientFactoryOptions Options { get; }
    }
}
