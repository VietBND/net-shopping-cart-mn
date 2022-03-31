using shopping_cart_infrastructures.RedisRepositories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietBND.Redis;

namespace shopping_cart_infrastructures.RedisRepositories
{
    public interface ISessionRedisRepository
    {
        Task<SessionCacheDto> GetCurrentAccount(string key);
        Task<bool> SetCurrentAccount(string key, SessionCacheDto value);
    }
    public class SessionRedisRepository : ISessionRedisRepository
    {
        private readonly IRedisStorage _redisStorage;
        public SessionRedisRepository(IRedisStorage redisStorage)
        {
            _redisStorage = redisStorage;
        }
        public async Task<SessionCacheDto> GetCurrentAccount(string key)
        {
           return await _redisStorage.StringGet<SessionCacheDto>(key);
        }

        public async Task<bool> SetCurrentAccount(string key, SessionCacheDto value)
        {
            return await _redisStorage.StringSet(key,value);
        }
    }
}
