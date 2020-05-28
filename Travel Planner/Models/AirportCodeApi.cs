using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Planner.Models
{

    public class AirportApi
    {
        public Airport[] airports { get; set; }
        public string term { get; set; }
        public int limit { get; set; }
        public int size { get; set; }
        public bool cached { get; set; }
        public bool status { get; set; }
        public int statusCode { get; set; }
    }

    public class Airport
    {
        public string name { get; set; }
        public string city { get; set; }
        public string iata { get; set; }
        public Child[] children { get; set; }
        public Country country { get; set; }
        public State state { get; set; }
    }

    public class Country
    {
        public string name { get; set; }
        public string iso { get; set; }
    }

    public class State
    {
        public string name { get; set; }
        public object abbr { get; set; }
    }

    public class Child
    {
        public string name { get; set; }
        public string city { get; set; }
        public string iata { get; set; }
        public State1 state { get; set; }
    }

    public class State1
    {
        public string name { get; set; }
        public object abbr { get; set; }
    }

}
