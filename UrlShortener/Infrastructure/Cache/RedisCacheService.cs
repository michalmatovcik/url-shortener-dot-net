using StackExchange.Redis;

namespace UrlShortener.Application;

public class RedisCacheService : ICacheService
{
    private readonly ConnectionMultiplexer _redis;
    private readonly IDatabase _database;

    public RedisCacheService(IConfiguration configuration)
    {
        _redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]!);
        _database = _redis.GetDatabase();
    }

    public async Task<string?> GetAsync(string key)
    {
        return await _database.StringGetAsync(key);
    }

    public async Task SetAsync(string key, string value)
    {
        await _database.StringSetAsync(key, value); //CR - S cache moc skusenosti nemam ale myslim, ze by bolo dobre aby mal nejaky cas, kedy expiruje. Ta metoda to priamo podporuje ako nepovinny argument
    }
}