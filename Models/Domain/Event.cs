namespace EventWhiz.Models.Domain
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? EventImgUrl { get; set; }
        public Guid LocationId { get; set; }
        public int EventTypeId { get; set; }

        // Navigation property for EventType & Location
        public EventType EventType { get; set; }
        public Location Location { get; set; }
    }

}
