using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using StudentsClubsWeb.Utilities;

namespace StudentsClubsWeb.Models
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? SchoolNumber { get; set; }
        public string? SchoolEmail { get; set; }
        [Required]
        public string DisplayUsername { get; set; } = NameGenerator.GenerateName();

    }
}
