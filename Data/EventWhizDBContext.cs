using EventWhiz.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventWhiz.Data
{
    public class EventWhizDBContext : DbContext
    {
        public EventWhizDBContext(DbContextOptions<EventWhizDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seed data using entityframework core for eventTypes
            //Small, Medium, Large

            var eventTypes = new List<EventType>()
            {
                new EventType { Id = 1, Name = "Small" },
                new EventType { Id = 2, Name = "Medium" },
                new EventType { Id = 3, Name = "Large" }
            };

            modelBuilder.Entity<EventType>().HasData(eventTypes);

            //seed data for locations
            var locations = new List<Location>()
            {
                new Location { Id = Guid.NewGuid(), Code = "LOC001", Name = "Location 1", LocationImgURL = "https://www.google.com" },
                new Location { Id = Guid.NewGuid(), Code = "LOC002", Name = "Location 2", LocationImgURL = "https://www.google.com" },
                new Location { Id = Guid.NewGuid(), Code = "LOC003", Name = "Location 3", LocationImgURL = "https://www.google.com" },
                new Location { Id = Guid.NewGuid(), Code = "LOC004", Name = "Location 4", LocationImgURL = "https://www.google.com" },
                new Location { Id = Guid.NewGuid(), Code = "LOC005", Name = "Location 5", LocationImgURL = "https://www.google.com" }
            };

            modelBuilder.Entity<Location>().HasData(locations);
        }
    }
}
