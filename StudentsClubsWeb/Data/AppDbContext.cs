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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>()
                .HasMany(u => u.Clubs)
                .WithMany(c => c.Members);

            builder.Entity<Club>()
                .HasMany(u => u.Admins)
                .WithOne();

            base.OnModelCreating(builder);
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
