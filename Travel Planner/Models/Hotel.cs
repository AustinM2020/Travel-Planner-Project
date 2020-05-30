using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Planner.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rate { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfRooms { get; set; }
        public DateTime? CheckIn { get; set; }
        public int Nights { get; set; }
        public string LinkName { get; set; }
        public string Link { get; set; }
        
        [ForeignKey("Vacation")]
        public int VacationId { get; set; }
        public Vacation Vacation { get; set; }
    }
}
