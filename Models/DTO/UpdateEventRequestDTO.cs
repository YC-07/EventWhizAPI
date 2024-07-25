using System.ComponentModel.DataAnnotations;

namespace EventWhiz.Models.DTO
{
    public class UpdateEventRequestDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        public string? EventImgUrl { get; set; }
        [Required]
        public Guid LocationId { get; set; }
        [Required]
        public int EventTypeId { get; set; }
    }
}
