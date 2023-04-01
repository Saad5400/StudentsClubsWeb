using StudentsClubsWeb.Models;

namespace StudentsClubsWeb.Areas.Student.Models
{
    public class HomeIndexVM
    {
        public List<Club> Clubs { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Post> Posts { get; set; }
    }
}
