using EventWhiz.Data;
using EventWhiz.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventWhiz.Repositories
{
    public class SQLEventRepository : IEventRepository
    {
        private readonly EventWhizDBContext dBContext;

        public SQLEventRepository(EventWhizDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<Event> CreateEvent(Event cEvent)
        {
            await dBContext.Events.AddAsync(cEvent);
            await dBContext.SaveChangesAsync();
            return await dBContext.Events.Include(e => e.Location).Include(e => e.EventType).FirstOrDefaultAsync(e => e.Id == cEvent.Id);

        }

        public async Task<Event?> DeleteEvent(Guid id)
        {
           var eventFromDB = await dBContext.Events.FirstOrDefaultAsync(e => e.Id == id);
           if(eventFromDB == null) return null;

           dBContext.Events.Remove(eventFromDB);
           await dBContext.SaveChangesAsync();
           return eventFromDB;
        }

        public async Task<Event?> GetEventById(Guid id)
        {
            return await dBContext.Events.Include("Location").Include("EventType").FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Event?> UpdateEvent(Guid id, Event cEvent)
        {
            var eventFromDB = await dBContext.Events.Include("Location").Include("EventType").FirstOrDefaultAsync(i => i.Id == id);
            if(eventFromDB == null) { return null; }
            eventFromDB.Name = cEvent.Name;
            eventFromDB.Description = cEvent.Description;
            eventFromDB.EventImgUrl = cEvent.EventImgUrl;
            eventFromDB.EventType = cEvent.EventType;
            eventFromDB.LocationId = cEvent.LocationId;

            await dBContext.SaveChangesAsync();
            return eventFromDB;
        }

        async public Task<List<Event>> GetAllEvent(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true,
            int pageNumer = 1, int pageSize = 1000)
        {
            var events = dBContext.Events.Include("Location").Include("EventType").AsQueryable();
            
            //Filtering
            if(string.IsNullOrWhiteSpace(filterOn)==false && string.IsNullOrEmpty(filterQuery)==false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    events = events.Where(i => i.Name.Contains(filterQuery));
                }
            }
            
            //Sorting
            if(string.IsNullOrEmpty(sortBy)==false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    events = isAscending? events.OrderBy(x => x.Name): events.OrderByDescending(x => x.Name);
                }
                else if(sortBy.Equals("Description", StringComparison.OrdinalIgnoreCase))
                {
                    events = isAscending ? events.OrderBy(x => x.Description) : events.OrderByDescending(x => x.Description);
                }
            }

            //Pagination
            var skipResults = (pageNumer - 1) * pageSize;


             return await events.Skip(skipResults).Take(pageSize).ToListAsync();
            //return await dBContext.Events.Include("Location").Include("EventType").ToListAsync();
        }
    }
}
