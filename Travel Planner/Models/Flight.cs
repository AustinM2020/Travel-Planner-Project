using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Planner.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        public string Flights { get; set; }
        public string Price { get; set; }

        [ForeignKey("Vacation")]
        public int VacationId { get; set; }
        public Vacation Vacation { get; set; }
    }
}
