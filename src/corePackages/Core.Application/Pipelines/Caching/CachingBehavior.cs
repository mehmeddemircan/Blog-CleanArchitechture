using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace Core.Application.Pipelines.Caching;

public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ICachableRequest
{
    private readonly IDistributedCache _cache;
    private readonly ILogger<CachingBehavior<TRequest, TResponse>> _logger;
    private readonly IConfiguration _configuration;

    public CachingBehavior(IDistributedCache cache, ILogger<CachingBehavior<TRequest, TResponse>> logger,
                          IConfiguration configuration)
    {
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)

    {
        // Check if caching is bypassed
        if (request.BypassCache)
            return await next();

        // Try to get cached response
        var cachedResponse = await _cache.GetStringAsync(request.CacheKey, cancellationToken);
        if (cachedResponse != null)
        {
            _logger.LogInformation($"Fetched from Cache -> {request.CacheKey}");
            return JsonConvert.DeserializeObject<TResponse>(cachedResponse);
        }

        // Execute the request handler and cache the response
        var response = await next();
        await CacheResponseAsync(request, response, cancellationToken);

        return response;
    }

    private async Task CacheResponseAsync(TRequest request, TResponse response, CancellationToken cancellationToken)
    {
        var slidingExpiration = GetSlidingExpiration();
        var cacheOptions = new DistributedCacheEntryOptions
        {
            SlidingExpiration = slidingExpiration
        };

        var serializedResponse = JsonConvert.SerializeObject(response);
        var encodedResponse = Encoding.UTF8.GetBytes(serializedResponse);
        await _cache.SetAsync(request.CacheKey, encodedResponse, cacheOptions, cancellationToken);

        _logger.LogInformation($"Added to Cache -> {request.CacheKey}");
    }

    private TimeSpan GetSlidingExpiration()
    {
        var slidingExpirationInDays = _configuration.GetValue<int>("CacheSettings:SlidingExpiration", 1);
        return TimeSpan.FromDays(slidingExpirationInDays);
    }
}