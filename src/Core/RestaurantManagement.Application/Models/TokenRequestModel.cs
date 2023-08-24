﻿using System.ComponentModel.DataAnnotations;


namespace RestaurantManagement.Application.Models
{
    public class TokenRequestModel
    {
        [Required, MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
    }
}
