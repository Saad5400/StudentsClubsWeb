using StudentsClubsWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentsClubsWeb.Areas.Student.Models
{
    public class CreateClubVM
    {
        [Required]
        public Club Club { get; set; }
        
        public List<Tag> TagsList { get; set; } = new List<Tag>();

        [Required(ErrorMessage = "هذه الخانة مطلوبة")]
        public String Tags { get; set; }

        public List<Tag>? Cities { get; set; }
        public List<Tag>? Schools { get; set; }

        [Required(ErrorMessage = "هذه الخانة مطلوبة")]
        public string City { get; set; }
        [Required(ErrorMessage = "هذه الخانة مطلوبة")]
        public string School { get; set; }
    }
}
