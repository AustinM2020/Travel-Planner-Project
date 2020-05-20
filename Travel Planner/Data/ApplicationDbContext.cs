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
                .HasData(
                    new IdentityRole
                    {
                        Name = "Traveler",
                        NormalizedName = "TRAVELER"
                    }
                );
        }
        public DbSet<Traveler> Travelers { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Excursion> Excursions { get; set; }
        public DbSet<Interest> Interests { get; set; }
    }
}
