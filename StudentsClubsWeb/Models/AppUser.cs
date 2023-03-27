using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace StudentsClubsWeb.Models
{
    public class AppUser : IdentityUser
    {
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        [Required]
        public String DisplayUsername { get; set; } = 

    }
}
