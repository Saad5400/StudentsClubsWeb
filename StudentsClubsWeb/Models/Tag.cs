using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsClubsWeb.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        public string AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        [ValidateNever]
        public AppUser Author { get; set; }
    }
}
