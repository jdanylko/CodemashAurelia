using CodemashApp.Repository;

namespace CodemashApp.Interfaces
{
    public interface ICodemashUnitOfWork
    {
        CacheSessionRepository SessionRepository { get; }
        CacheSpeakerRepository SpeakerRepository { get; }
    }
}