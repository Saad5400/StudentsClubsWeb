using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StudentsClubsWeb.Models
{
    public class ClubAdmin
    {
        [Key]
        public int Id { get; set; }

        public int ClubId { get; set; }
        [ForeignKey(nameof(ClubId))]
        [ValidateNever]
        public Club Club { get; set; }

        public string AdminId { get; set; }
        [ForeignKey(nameof(AdminId))]
        [ValidateNever]
        public AppUser Admin { get; set; }
    }
}
