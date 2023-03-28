using Microsoft.Build.Framework;
using StudentsClubsWeb.Models;

namespace StudentsClubsWeb.Areas.Student.Models
{
    public class CreateClubVM
    {
        [Required]
        public Club Club { get; set; }
        
        public List<Tag> TagsList { get; set; } = new List<Tag>();

        [Required]
        public String Tags { get; set; }
    }
}
