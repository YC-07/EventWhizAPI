using EventWhiz.Models.Domain;

namespace EventWhiz.Repositories
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllEvent(string? filterOn = null, string? filterQuery=null, 
            string? sortBy=null, bool isAscending=true,
            int pageNumer=1, int pageSize=1000);
        Task<Event?> GetEventById(Guid id);
        Task<Event> CreateEvent(Event cEvent);
        Task<Event?> UpdateEvent(Guid id, Event cEvent);
        Task<Event?> DeleteEvent(Guid id);
    }
}
