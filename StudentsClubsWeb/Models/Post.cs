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
        [Required]
        public string Content { get; set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();

        public string AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        [ValidateNever]
        public AppUser Author { get; set; }
    }
}
