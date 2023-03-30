using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StudentsClubsWeb.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [StringLength(500)]
        [Required]
        public string Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;


        public List<Tag> Tags { get; set; } = new List<Tag>();

        public string AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        [ValidateNever]
        public AppUser Author { get; set; }

        public int? ClubId { get; set; }
        [ForeignKey(nameof(ClubId))]
        [ValidateNever]
        public Club? Club { get; set; }
    }
}
