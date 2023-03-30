using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StudentsClubsWeb.Models
{
    public class JoinClubRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        [ValidateNever]
        public AppUser User { get; set; }

        [Required]
        public int ClubId { get; set; }
        [ForeignKey(nameof(ClubId))]
        [ValidateNever]
        public Club Club { get; set; }


        public bool IsApproved { get; set; }
    }
}
