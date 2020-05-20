using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Planner.Models
{

    public class HotelApi
    {
        public int id { get; set; }
        public string name { get; set; }
        public string thumbnailUrl { get; set; }
        public float starRating { get; set; }
        public Urls urls { get; set; }
        public Address address { get; set; }
        public Guestreviews guestReviews { get; set; }
        public Landmark[] landmarks { get; set; }
        public Rateplan ratePlan { get; set; }
        public string neighbourhood { get; set; }
        public Deals deals { get; set; }
        public Messaging messaging { get; set; }
        public Badging badging { get; set; }
        public string pimmsAttributes { get; set; }
        public Coordinate coordinate { get; set; }
        public string providerType { get; set; }
        public int supplierHotelId { get; set; }
        public bool isAlternative { get; set; }
    }

    public class Urls
    {
    }

    public class Address
    {
        public string streetAddress { get; set; }
        public string extendedAddress { get; set; }
        public string locality { get; set; }
        public string postalCode { get; set; }
        public string region { get; set; }
        public string countryName { get; set; }
        public string countryCode { get; set; }
    }

    public class Guestreviews
    {
        public float unformattedRating { get; set; }
        public string rating { get; set; }
        public int total { get; set; }
        public int scale { get; set; }
    }

    public class Rateplan
    {
        public Price price { get; set; }
        public Features features { get; set; }
    }

    public class Price
    {
        public string current { get; set; }
        public float exactCurrent { get; set; }
    }

    public class Features
    {
        public bool paymentPreference { get; set; }
        public bool noCCRequired { get; set; }
    }

    public class Deals
    {
    }

    public class Messaging
    {
    }

    public class Badging
    {
    }

    public class Coordinate
    {
        public float lat { get; set; }
        public float lon { get; set; }
    }

    public class Landmark
    {
        public string label { get; set; }
        public string distance { get; set; }
    }

}
