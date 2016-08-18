using System;
using CodemashApp.Configuration;
using CodemashApp.Interfaces;
using CodemashApp.Repository;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace CodemashApp.UnitOfWork
{
    public class CodemashUnitOfWork : ICodemashUnitOfWork
    {
        private readonly IOptions<CodemashConfiguration> _settings;

        private static CacheSessionRepository _sessionRepository;
        private static CacheSpeakerRepository _speakerRepository;
        private readonly IMemoryCache _cache;

        public CodemashUnitOfWork(IOptions<CodemashConfiguration> settings, IMemoryCache cache)
        {
            _settings = settings;
            _cache = cache;
        }

        #region Repositories

        public CacheSessionRepository SessionRepository
        {
            get
            {
                return _sessionRepository
                       ?? (_sessionRepository =
                           new CacheSessionRepository(
                               new Uri(_settings.Value.SessionUrl), _cache));
            }
        }

        public CacheSpeakerRepository SpeakerRepository
            => _speakerRepository
               ?? (_speakerRepository =
                   new CacheSpeakerRepository(
                       new Uri(_settings.Value.SpeakerUrl), _cache));

        #endregion
    }
}