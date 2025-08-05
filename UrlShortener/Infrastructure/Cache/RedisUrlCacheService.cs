using StackExchange.Redis;

namespace UrlShortener.Application;

public class RedisUrlCacheService : IUrlCacheService
{
    private readonly ConnectionMultiplexer _redis;
    private readonly IDatabase _database;

    public RedisUrlCacheService(IConfiguration configuration)
    {
        _redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]!);
        _database = _redis.GetDatabase();
    }

    public async Task<string?> GetUrlHashAsync(string url)
    {
        return await _database.StringGetAsync(url);
    }

    public async Task SetAsync(string urlHash, string url)
    {
        await _database.StringSetAsync(urlHash, url);
    }
}