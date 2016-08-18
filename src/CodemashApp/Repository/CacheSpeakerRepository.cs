using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodemashApp.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CodemashApp.Repository
{
    public class CacheSpeakerRepository : SpeakerRepository
    {
        private readonly IMemoryCache _cache;
        public CacheSpeakerRepository(Uri url, IMemoryCache cache) : base(url)
        {
            _cache = cache;
        }

        public override async Task<IEnumerable<Speaker>> GetAllAsync()
        {
            IEnumerable<Speaker> result;
            const string cacheKey = "CachedCodemashSpeakerRepository:GetAllAsync";

            if (!_cache.TryGetValue(cacheKey, out result)) return result;

            if (result != null) return result;

            var options = new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(15)
            };

            result = await base.GetAllAsync();

            _cache.Set(cacheKey, result, options);

            return result;
        }

    }
}