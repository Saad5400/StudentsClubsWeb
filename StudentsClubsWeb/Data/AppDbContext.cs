using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentsClubsWeb.Models;

namespace StudentsClubsWeb.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
