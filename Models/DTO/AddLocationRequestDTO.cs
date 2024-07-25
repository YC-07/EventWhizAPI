﻿using System.ComponentModel.DataAnnotations;

namespace EventWhiz.Models.DTO
{
    public class AddLocationRequestDTO
    {
        [Required]
        [MinLength(3,ErrorMessage="Code has to be minimum of 3 characters")]
        [MaxLength(3,ErrorMessage = "Code has to be maximum of 3 characters")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100,ErrorMessage ="Name has to be maximum of 100 characters")]
        public string Name { get; set; }
        public string? LocationImgURL { get; set; }
    }
}
