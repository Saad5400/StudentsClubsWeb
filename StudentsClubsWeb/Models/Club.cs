﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StudentsClubsWeb.Models
{
    public class Club
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        public List<AppUser> Members { get; set; } = new List<AppUser>();

        public List<AppUser> Admins { get; set; } = new List<AppUser>();

        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}