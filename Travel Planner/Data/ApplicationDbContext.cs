using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Travel_Planner.Models;

namespace Travel_Planner.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole { Name = "Traveler", NormalizedName = "TRAVELER" });
            builder.Entity<Interest>()
                .HasData(new Interest { Id = 1, Name = "Parks" });
            builder.Entity<Interest>()
                .HasData(new Interest { Id = 2, Name = "Art" });
            builder.Entity<Interest>()
                .HasData(new Interest { Id = 3, Name = "Museums" });
            builder.Entity<Interest>()
                .HasData(new Interest { Id = 4, Name = "Local Attractions" });
            builder.Entity<Interest>()
                .HasData(new Interest { Id = 6, Name = "Live Music" });
            builder.Entity<Interest>()
                .HasData(new Interest { Id = 7, Name = "Nightlife" });
            builder.Entity<Interest>()
                .HasData(new Interest { Id = 8, Name = "Movies" });       
        }
        public DbSet<Traveler> Travelers { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Excursion> Excursions { get; set; }
        public DbSet<Interest> Interests { get; set; }
    }
}
