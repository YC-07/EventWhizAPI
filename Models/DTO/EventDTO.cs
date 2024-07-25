using EventWhiz.Models.Domain;

namespace EventWhiz.Models.DTO
{
    public class EventDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? EventImgUrl { get; set; }
        public Guid LocationId { get; set; }
        public int EventTypeId { get; set; }

        public LocationDTO Location { get; set; }
        public EventTypeDTO EventType { get; set; }
    }
}
