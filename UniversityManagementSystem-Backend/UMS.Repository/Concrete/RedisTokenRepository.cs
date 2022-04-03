﻿using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UMS.Data.Entities;
using UMS.Repository.Abstract;

namespace UMS.Repository.Concrete
{
    public class RedisTokenRepository : IRedisTokenRepository
    {
        private readonly IDistributedCache _distributedCache;

        public RedisTokenRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task Set(RedisToken token, int expireInMinutes)
        {
            await _distributedCache.SetStringAsync(token.TokenValue, JsonSerializer.Serialize(token), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(expireInMinutes)
            });
        }

        public async Task<RedisToken> Get(string key)
        {
            var data = await _distributedCache.GetStringAsync(key);
            if (data == null)
                return null;
            return JsonSerializer.Deserialize<RedisToken>(data);
        }

        public async Task Remove(string key)
        {
            await _distributedCache.RemoveAsync(key);
        }
    }
}