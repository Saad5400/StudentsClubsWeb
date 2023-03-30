﻿using StudentsClubsWeb.Models;

namespace StudentsClubsWeb.Areas.Admin.Models
{
    public class ClubsIndexVM
    {
        public IEnumerable<Club> Clubs { get; set; }
        public IEnumerable<AppUser> AppUsers { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}