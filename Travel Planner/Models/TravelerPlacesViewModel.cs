﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Planner.Models
{
    public class TravelerPlacesViewModel
    {
        public PlaceResults PlacesOne { get; set; } 
        public PlaceResults PlacesTwo { get; set; }
        public PlaceResults PlacesThree { get; set; }
        public Vacation Vacation { get; set; }
        public List<Vacation> Vacations { get; set; }
        public Traveler Traveler { get; set; }
        public HotelApi HotelApi { get; set; }
    }
}
