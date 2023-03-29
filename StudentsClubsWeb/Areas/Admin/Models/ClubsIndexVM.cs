using StudentsClubsWeb.Models;

namespace StudentsClubsWeb.Areas.Admin.Models
{
    public class ClubsIndexVM
    {
        public IEnumerable<Club> Clubs { get; set; }
        public IEnumerable<AppUser> AppUsers { get; set; }
    }
}
