using DatabaseAccess.Entities;
using DatabaseAccess.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var appUser = new ApplicationUser
            {
                Id = "e7985cd6-96b2-498e-83c9-a7eb99bf071b",
                Email = "admin@localhost",
                EmailConfirmed = true,
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin@localhost",
                NormalizedEmail = "ADMIN@LOCALHOST",
                NormalizedUserName = "ADMIN@LOCALHOST",
                Role = RoleType.Admin
            };

            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();
            appUser.PasswordHash = hasher.HashPassword(appUser, "admin");

            builder.Entity<ApplicationUser>().HasData(appUser);
        }

        public DbSet<JobApplication> JobApplications { get; set; } = null!;
        public DbSet<JobPost> JobPosts { get; set; } = null!;

    }
}