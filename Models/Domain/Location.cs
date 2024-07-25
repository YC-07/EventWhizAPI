namespace EventWhiz.Models.Domain
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? LocationImgURL { get; set; }
    }

}
