using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Planner.Models
{

    public class HotelApi
    {
        public string result { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public Body body { get; set; }
        public Common common { get; set; }
    }

    public class Body
    {
        public string header { get; set; }
        public Query query { get; set; }
        public Searchresults searchResults { get; set; }
        public Sortresults sortResults { get; set; }
        public Filters filters { get; set; }
        public Pointofsale pointOfSale { get; set; }
        public Miscellaneous miscellaneous { get; set; }
        public Pageinfo pageInfo { get; set; }
    }

    public class Query
    {
        public Destination destination { get; set; }
    }

    public class Destination
    {
        public string id { get; set; }
        public string value { get; set; }
        public string resolvedLocation { get; set; }
    }

    public class Searchresults
    {
        public int totalCount { get; set; }
        public Result[] results { get; set; }
        public Pagination pagination { get; set; }
    }

    public class Pagination
    {
        public int currentPage { get; set; }
        public string pageGroup { get; set; }
        public int nextPageNumber { get; set; }
        public string nextPageGroup { get; set; }
    }

    public class Result
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
        public string badge { get; set; }
        public string badgeText { get; set; }
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
        public string old { get; set; }
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

    public class Sortresults
    {
        public Option[] options { get; set; }
        public float distanceOptionLandmarkId { get; set; }
    }

    public class Option
    {
        public string label { get; set; }
        public string itemMeta { get; set; }
        public Choice[] choices { get; set; }
        public Enhancedchoice[] enhancedChoices { get; set; }
        public string selectedChoiceLabel { get; set; }
    }

    public class Choice
    {
        public string label { get; set; }
        public string value { get; set; }
        public bool selected { get; set; }
    }

    public class Enhancedchoice
    {
        public string label { get; set; }
        public string itemMeta { get; set; }
        public Choice1[] choices { get; set; }
    }

    public class Choice1
    {
        public string label { get; set; }
        public float id { get; set; }
    }

    public class Filters
    {
        public bool applied { get; set; }
        public Name name { get; set; }
        public Starrating starRating { get; set; }
        public Guestrating guestRating { get; set; }
        public Landmarks landmarks { get; set; }
        public Neighbourhood neighbourhood { get; set; }
        public Accommodationtype accommodationType { get; set; }
        public Facilities facilities { get; set; }
        public Accessibility accessibility { get; set; }
        public Themesandtypes themesAndTypes { get; set; }
        public Price1 price { get; set; }
        public Paymentpreference paymentPreference { get; set; }
        public Welcomerewards welcomeRewards { get; set; }
    }

    public class Name
    {
        public Item item { get; set; }
        public Autosuggest autosuggest { get; set; }
    }

    public class Item
    {
        public string value { get; set; }
    }

    public class Autosuggest
    {
        public Additionalurlparams additionalUrlParams { get; set; }
    }

    public class Additionalurlparams
    {
        public string resolvedlocation { get; set; }
        public string qdestination { get; set; }
        public string destinationid { get; set; }
    }

    public class Starrating
    {
        public bool applied { get; set; }
        public Item1[] items { get; set; }
    }

    public class Item1
    {
        public int value { get; set; }
    }

    public class Guestrating
    {
        public Range range { get; set; }
    }

    public class Range
    {
        public Min min { get; set; }
        public Max max { get; set; }
    }

    public class Min
    {
        public float defaultValue { get; set; }
    }

    public class Max
    {
        public float defaultValue { get; set; }
    }

    public class Landmarks
    {
        public object[] selectedOrder { get; set; }
        public Item2[] items { get; set; }
        public object[] distance { get; set; }
    }

    public class Item2
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Neighbourhood
    {
        public bool applied { get; set; }
        public Item3[] items { get; set; }
    }

    public class Item3
    {
        public string label { get; set; }
        public int value { get; set; }
    }

    public class Accommodationtype
    {
        public bool applied { get; set; }
        public Item4[] items { get; set; }
    }

    public class Item4
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Facilities
    {
        public bool applied { get; set; }
        public Item5[] items { get; set; }
    }

    public class Item5
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Accessibility
    {
        public bool applied { get; set; }
        public Item6[] items { get; set; }
    }

    public class Item6
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Themesandtypes
    {
        public bool applied { get; set; }
        public Item7[] items { get; set; }
    }

    public class Item7
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Price1
    {
        public string label { get; set; }
        public Range1 range { get; set; }
        public int multiplier { get; set; }
    }

    public class Range1
    {
        public Min1 min { get; set; }
        public Max1 max { get; set; }
        public int increments { get; set; }
    }

    public class Min1
    {
        public int defaultValue { get; set; }
    }

    public class Max1
    {
        public int defaultValue { get; set; }
    }

    public class Paymentpreference
    {
        public Item8[] items { get; set; }
    }

    public class Item8
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Welcomerewards
    {
        public string label { get; set; }
        public Item9[] items { get; set; }
    }

    public class Item9
    {
        public string label { get; set; }
        public string value { get; set; }
    }

    public class Pointofsale
    {
        public Currency currency { get; set; }
    }

    public class Currency
    {
        public string code { get; set; }
        public string symbol { get; set; }
        public string separators { get; set; }
        public string format { get; set; }
    }

    public class Miscellaneous
    {
        public string pageViewBeaconUrl { get; set; }
    }

    public class Pageinfo
    {
        public string pageType { get; set; }
    }

    public class Common
    {
        public Pointofsale1 pointOfSale { get; set; }
        public Tracking tracking { get; set; }
    }

    public class Pointofsale1
    {
        public string numberSeparators { get; set; }
        public string brandName { get; set; }
    }

    public class Tracking
    {
        public Omniture omniture { get; set; }
    }

    public class Omniture
    {
        public string sprop33 { get; set; }
        public string sprop32 { get; set; }
        public string sprop74 { get; set; }
        public string sproducts { get; set; }
        public string seVar16 { get; set; }
        public string seVar40 { get; set; }
        public string seVar41 { get; set; }
        public string seVar63 { get; set; }
        public string seVar42 { get; set; }
        public string seVar4 { get; set; }
        public string seVar43 { get; set; }
        public string seVar2 { get; set; }
        public string seVar24 { get; set; }
        public string seVar7 { get; set; }
        public string sserver { get; set; }
        public string seVar6 { get; set; }
        public string sprop29 { get; set; }
        public string sprop27 { get; set; }
        public string seVar9 { get; set; }
        public string seVar69 { get; set; }
        public string scurrencyCode { get; set; }
        public string seVar29 { get; set; }
        public string sprop9 { get; set; }
        public string sprop8 { get; set; }
        public string seVar95 { get; set; }
        public string sprop7 { get; set; }
        public string seVar31 { get; set; }
        public string seVar32 { get; set; }
        public string seVar33 { get; set; }
        public string seVar34 { get; set; }
        public string seVar13 { get; set; }
        public string sprop18 { get; set; }
        public string sprop5 { get; set; }
        public string sprop15 { get; set; }
        public string sprop3 { get; set; }
        public string sprop14 { get; set; }
        public string sprop36 { get; set; }
        public string seVar93 { get; set; }
        public string sprop2 { get; set; }
    }

}
