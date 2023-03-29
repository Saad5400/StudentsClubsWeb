using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StudentsClubsWeb.Models
{
    public class Club
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "هذه الخانة مطلوبة")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "هذه الخانة مطلوبة")]
        [StringLength(2000)]
        public string Description { get; set; }

        public List<AppUser> Members { get; set; } = new List<AppUser>();

        public List<ClubAdmin> ClubAdmins { get; set; } = new List<ClubAdmin>();

        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
