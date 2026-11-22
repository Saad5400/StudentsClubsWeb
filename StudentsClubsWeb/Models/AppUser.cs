using Microsoft.AspNetCore.Identity;
using StudentsClubsWeb.Utilities;

namespace StudentsClubsWeb.Models
{
    public class AppUser : IdentityUser
    {
        // Non-nullable, so EF already maps it NOT NULL. The [Required] that sat here came
        // from Microsoft.Build.Framework (a stray IDE import) and did nothing at runtime.
        public string DisplayUsername { get; set; } = NameGenerator.GenerateName();

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? SchoolNumber { get; set; }
        public string? SchoolEmail { get; set; }


        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<Club> Clubs { get; set; } = new List<Club>();
        public List<ClubAdmin> ClubAdmins { get; set; } = new List<ClubAdmin>();

    }
}
