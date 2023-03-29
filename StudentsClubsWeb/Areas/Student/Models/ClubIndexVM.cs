using StudentsClubsWeb.Models;

namespace StudentsClubsWeb.Areas.Student.Models
{
    public class ClubIndexVM
    {
        public List<Club> Clubs { get; set; } = new List<Club>();
        public List<Tag> Tags { get; set; } = new List<Tag>();

        public string? FilterCity { get; set; }
        public string? FilterSchool { get; set; }
        public string? FilterTag { get; set; }

    }
}
