using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Planner.Models
{
    public class Vacation
    {
        [Key]
        public int Id { get; set; }
        public string Destination { get; set; }
        public string DestinationId { get; set; }
        public DateTime? VacationStart { get; set; }
        public DateTime? VacationEnd { get; set; }
        public List<Excursion> Excursions { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }

        [ForeignKey("Traveler")]
        public int TravelerId { get; set; }
        public Traveler Traveler { get; set; }
    }
}
