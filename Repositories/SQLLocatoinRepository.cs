using EventWhiz.Data;
using EventWhiz.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventWhiz.Repositories
{
    public class SQLLocatoinRepository : ILocationRepository
    {
        private readonly EventWhizDBContext _dbContext;
        public SQLLocatoinRepository(EventWhizDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Location> CreateLocation(Location location)
        {
            await _dbContext.Locations.AddAsync(location);
            await _dbContext.SaveChangesAsync();
            return location;
        }

        public async Task<Location?> DeleteLocation(Guid id)
        {
                var locationExists = await _dbContext.Locations.FirstOrDefaultAsync(x => x.Id == id);
                if (locationExists == null) return null;

                _dbContext.Locations.Remove(locationExists);
                await _dbContext.SaveChangesAsync();
                return locationExists;
        }

        public async Task<List<Location>> GetAllLocations()
        {
           //fetch all locations from database
           return await _dbContext.Locations.ToListAsync();
        }

        public async Task<Location?> GetLocationById(Guid id)
        {
           return await _dbContext.Locations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Location?> UpdateLocation(Guid id, Location location)
        {
                var locationToUpdate = await _dbContext.Locations.FirstOrDefaultAsync(x => x.Id==id);
                if (locationToUpdate == null) return null;

                locationToUpdate.Code = location.Code;
                locationToUpdate.Name = location.Name;
                locationToUpdate.LocationImgURL = location.LocationImgURL;
                await _dbContext.SaveChangesAsync();
                return locationToUpdate;
        }
    }
}
