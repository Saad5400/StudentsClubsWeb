using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using StudentsClubsWeb.Utilities;

namespace StudentsClubsWeb.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string DisplayUsername { get; set; } = NameGenerator.GenerateName();

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? SchoolNumber { get; set; }
        public string? SchoolEmail { get; set; }


        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<Club> Clubs { get; set; } = new List<Club>();
    }
}
