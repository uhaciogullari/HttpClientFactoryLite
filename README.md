HttpClientFactoryLite
===============

[Microsoft.Extensions.Http][0] fork with no dependencies.

[![NuGet version](https://img.shields.io/nuget/v/HttpClientFactoryLite.svg)](https://www.nuget.org/packages/HttpClientFactoryLite/)

## Why?

[As you well know, HttpClient has problems][1]. Create an instance for every request and you will run into socket exhaustion. Make it a singleton and it will not respect DNS changes.

ASP.NET team created the [HttpClientFactory][2] to fix the issue. However it was implemented in an opinionated way, too opinionated for my case. While I love dependency injection and ASP.NET as much as the next person, there are a few cases where you don't want to or can't bring in all those dependencies. It should be possible to new up an HttpClientFactory and put it in a static field if you are not into dependency injection. You could also be completely happy with another DI container and don't want to mix it up with ASP.NET stuff.

Fortunately the code is licensed under Apache License so we are free to surgically remove the parts we don't want.

The end result:

```csharp
var httpClientFactory = new HttpClientFactory(); //bliss
```

If you are using dependency injection, make sure that IHttpClientFactory is registered as a singleton.

## What's different?

The changes in the public interface are kept to a minimum.

### Configuration

Configuration was done through DI in the original library. IHttpClientFactory.Register method was introduced to provide the same functionality. A few examples:

```csharp
httpClientFactory.Register("github", builder => builder
    // Configure HttpClient before it's returned
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.github.com/"))
    // Customize the primary HttpClientHandler
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler { UseCookies = true })
    // Set HttpMessageHandler lifetime
    .SetHandlerLifetime(TimeSpan.FromMinutes(10)));
```
You can also specify a type as a key during registration and client creation:
```csharp
httpClientFactory.Register<GithubClient>(builder =>
    builder.ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.github.com/")));

// before the request
var client = httpClientFactory.CreateClient<GithubClient>();
```

### Logging

All logging related code is removed to make sure that the library has no dependencies. 

### Typed clients

Typed clients are removed because they were tightly coupled to the dependency injection infrastructure.

### Your repository is too many commits behind

I forked [the last stable release branch][3], you can see [the full diff here][4]. Keep in mind that the original repo has many libraries in it and it's safe to assume that most of the commits won't be related to HttpClientFactory. I will take another look when there's a new stable release.

## Feedback

Let me know if there's something missing. I didn't get to fix the tests and Polly project yet.

[0]: https://www.nuget.org/packages/Microsoft.Extensions.Http

[1]: https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests

[2]: https://github.com/aspnet/Extensions/tree/master/src/HttpClientFactory

[3]: https://github.com/aspnet/Extensions/tree/release/2.2

[4]: https://github.com/aspnet/Extensions/compare/release%2F2.2...uhaciogullari:hcf-lite?diff
