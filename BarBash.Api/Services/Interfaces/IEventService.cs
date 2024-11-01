using BarBash.Api.Models;

namespace BarBash.Api.Services.Interfaces
{
    public interface IEventService
    {
        Task<List<Event>> GetEventsAsync();
    }
}
