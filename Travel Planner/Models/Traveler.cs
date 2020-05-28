using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Planner.Models
{
    public class Traveler
    {
        [Key]
        public int Id { get; set; }
        public int VacationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        public string InterestOne { get; set; }
        public string InterestTwo { get; set; }
        public string InterestThree { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
        public List<Vacation> Vacations { get; set; }
        
        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
