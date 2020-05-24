using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Planner.Models
{
    public class TravelerPlacesViewModel
    {
        public PlaceResults PlaceResults { get; set; }
        public List<Vacation> Vacations { get; set; }
        public Traveler Traveler { get; set; }
    }
}
