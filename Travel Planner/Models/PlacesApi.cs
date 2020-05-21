using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Planner.Models
{

    public class PlaceResults
    {
        public object[] html_attributions { get; set; }
        public string next_page_token { get; set; }
        public Places[] results { get; set; }
        public string status { get; set; }
    }

    public class Places
    {
        public string business_status { get; set; }
        public string formatted_address { get; set; }
        public PlaceGeometry geometry { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public bool permanently_closed { get; set; }
        public Photo[] photos { get; set; }
        public string place_id { get; set; }
        public PlacePlus_Code plus_code { get; set; }
        public float rating { get; set; }
        public string reference { get; set; }
        public string[] types { get; set; }
        public int user_ratings_total { get; set; }
        public Opening_Hours opening_hours { get; set; }
    }

    public class PlaceGeometry
    {
        public PlaceLocation location { get; set; }
        public PlaceViewport viewport { get; set; }
    }

    public class PlaceLocation
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class PlaceViewport
    {
        public PlaceNortheast northeast { get; set; }
        public PlaceSouthwest southwest { get; set; }
    }

    public class PlaceNortheast
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class PlaceSouthwest
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class PlacePlus_Code
    {
        public string compound_code { get; set; }
        public string global_code { get; set; }
    }

    public class Opening_Hours
    {
        public bool open_now { get; set; }
    }

    public class Photo
    {
        public int height { get; set; }
        public string[] html_attributions { get; set; }
        public string photo_reference { get; set; }
        public int width { get; set; }
    }
}
