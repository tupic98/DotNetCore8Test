﻿using System.ComponentModel.DataAnnotations;

namespace TOPCustomOrders.API.Models.DTO
{
    public class AddRegionRequestDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to be a minimum of 3 characters")]
        [MaxLength(4, ErrorMessage = "Code has to be a maximum of 4 characters")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
