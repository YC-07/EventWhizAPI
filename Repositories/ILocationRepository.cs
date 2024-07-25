using EventWhiz.Models.Domain;

namespace EventWhiz.Repositories
{
    public interface ILocationRepository
    {
        //code to get all locations
        Task<List<Location>> GetAllLocations();

        Task<Location?> GetLocationById(Guid id);
        Task<Location> CreateLocation(Location location);
        Task<Location?> UpdateLocation(Guid id, Location location);
        Task<Location?> DeleteLocation(Guid id);
    }
}
