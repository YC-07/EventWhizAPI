using EventWhiz.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace EventWhiz.Models.DTO
{
    public class AddEventRequestDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        public string? EventImgUrl { get; set; }

        [Required]
        public Guid LocationId { get; set; }
        [Required]
        [Range(1, 3, ErrorMessage = "The integer must be between 1 and 3.")]
        public int EventTypeId { get; set; }

    }
}
