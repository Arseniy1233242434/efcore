using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EfCore.Data
{
    
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<InterestGroup> InterestGroups { get; set; }
        public DbSet<UserInterestGroup> UserInterestGroups { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder
        optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-60C99SS\\SQLEXPRESS;Database=UserDb;Trusted_Connection=true;TrustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(s => s.UserProfile)
            .WithOne(ps => ps.User)
            .HasForeignKey<UserProfile>(ps => ps.UserId);

            modelBuilder.Entity<Role>() 
.HasMany(g => g.Users)
.WithOne(s => s.Role)
.HasForeignKey(s => s.RoleId);


            modelBuilder.Entity<UserInterestGroup>()
.HasKey(cs => new { cs.UserId, cs.InterestGroupId });

            modelBuilder.Entity<UserInterestGroup>()
.HasOne(cs => cs.User)
.WithMany(s => s.InterestGroups)
.HasForeignKey(cs => cs.UserId);

            modelBuilder.Entity<UserInterestGroup>()
.HasOne(cs => cs.InterestGroup)
.WithMany(c => c.Users)
.HasForeignKey(cs => cs.InterestGroupId);

        }
    }
}
