using StudentsClubsWeb.Models;

namespace StudentsClubsWeb.Areas.Student.Models
{
    public class ClubIndexVM
    {
        public List<Club> Clubs { get; set; } = new List<Club>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<Tag> Cities { get; set; } = new List<Tag>();
        public List<Tag> Schools { get; set; } = new List<Tag>();
    }
}
