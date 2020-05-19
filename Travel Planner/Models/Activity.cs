using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Planner.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Importance { get; set; }
        public DateTime? Date { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }

        [ForeignKey("Traveler")]
        public string TravelerId { get; set; }
        public Traveler Traveler { get; set; }
    }
}
