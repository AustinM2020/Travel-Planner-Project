//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Travel_Planner.Models
//{

//    public class Rootobject
//    {
//        public Datum[] data { get; set; }
//        public Status status { get; set; }
//        public Paging paging { get; set; }
//    }

//    public class Status
//    {
//        public string unfiltered_total_size { get; set; }
//        public string pricing_disclaimer { get; set; }
//        public string unavailable { get; set; }
//        public string commerce_country_iso_code { get; set; }
//        public string no_prices { get; set; }
//        public bool autobroadened { get; set; }
//        public string progress { get; set; }
//        public string auction_key { get; set; }
//        public string primary_geo { get; set; }
//        public string impression_key { get; set; }
//        public string pricing { get; set; }
//        public string doubleClickZone { get; set; }
//    }

//    public class Paging
//    {
//        public string results { get; set; }
//        public string total_results { get; set; }
//    }

//    public class Datum
//    {
//        public string location_id { get; set; }
//        public string name { get; set; }
//        public string latitude { get; set; }
//        public string longitude { get; set; }
//        public string num_reviews { get; set; }
//        public string timezone { get; set; }
//        public string location_string { get; set; }
//        public Photo photo { get; set; }
//        public Award[] awards { get; set; }
//        public string preferred_map_engine { get; set; }
//        public string raw_ranking { get; set; }
//        public string ranking_geo { get; set; }
//        public string ranking_geo_id { get; set; }
//        public string ranking_position { get; set; }
//        public string ranking_denominator { get; set; }
//        public string ranking_category { get; set; }
//        public string ranking { get; set; }
//        public string subcategory_type { get; set; }
//        public string subcategory_type_label { get; set; }
//        public string distance { get; set; }
//        public object distance_string { get; set; }
//        public string bearing { get; set; }
//        public string rating { get; set; }
//        public bool is_closed { get; set; }
//        public bool is_long_closed { get; set; }
//        public string price_level { get; set; }
//        public Neighborhood_Info[] neighborhood_info { get; set; }
//        public Hac_Offers hac_offers { get; set; }
//        public string hotel_class { get; set; }
//        public Business_Listings business_listings { get; set; }
//        public Special_Offers special_offers { get; set; }
//        public string listing_key { get; set; }
//        public string price { get; set; }
//        public string hotel_class_attribution { get; set; }
//    }

//    public class Photo
//    {
//        public Images images { get; set; }
//        public bool is_blessed { get; set; }
//        public DateTime uploaded_date { get; set; }
//        public string caption { get; set; }
//        public string id { get; set; }
//        public string helpful_votes { get; set; }
//        public DateTime published_date { get; set; }
//        public User user { get; set; }
//    }

//    public class Images
//    {
//        public Small small { get; set; }
//        public Thumbnail thumbnail { get; set; }
//        public Original original { get; set; }
//        public Large large { get; set; }
//        public Medium medium { get; set; }
//    }

//    public class Small
//    {
//        public string width { get; set; }
//        public string url { get; set; }
//        public string height { get; set; }
//    }

//    public class Thumbnail
//    {
//        public string width { get; set; }
//        public string url { get; set; }
//        public string height { get; set; }
//    }

//    public class Original
//    {
//        public string width { get; set; }
//        public string url { get; set; }
//        public string height { get; set; }
//    }

//    public class Large
//    {
//        public string width { get; set; }
//        public string url { get; set; }
//        public string height { get; set; }
//    }

//    public class Medium
//    {
//        public string width { get; set; }
//        public string url { get; set; }
//        public string height { get; set; }
//    }

//    public class User
//    {
//        public object user_id { get; set; }
//        public string member_id { get; set; }
//        public string type { get; set; }
//    }

//    public class Hac_Offers
//    {
//        public string availability { get; set; }
//        public Offer[] offers { get; set; }
//        public object[] all_booking_offers { get; set; }
//    }

//    public class Offer
//    {
//        public string content_id { get; set; }
//        public string provider_display_name { get; set; }
//        public string internal_provider_name { get; set; }
//        public string logo { get; set; }
//        public string treatment { get; set; }
//        public bool is_bookable { get; set; }
//        public string availability { get; set; }
//        public string display_style { get; set; }
//        public string link { get; set; }
//        public string auction_offer_key { get; set; }
//    }

//    public class Business_Listings
//    {
//        public Desktop_Contacts[] desktop_contacts { get; set; }
//        public object[] mobile_contacts { get; set; }
//    }

//    public class Desktop_Contacts
//    {
//        public string value { get; set; }
//        public string label { get; set; }
//        public string type { get; set; }
//    }

//    public class Special_Offers
//    {
//        public Desktop[] desktop { get; set; }
//        public object[] mobile { get; set; }
//    }

//    public class Desktop
//    {
//        public string headline { get; set; }
//        public string url { get; set; }
//        public string offerless_click_tracking_url { get; set; }
//    }

//    public class Award
//    {
//        public string award_type { get; set; }
//        public string year { get; set; }
//        public Images1 images { get; set; }
//        public string[] categories { get; set; }
//        public string display_name { get; set; }
//    }

//    public class Images1
//    {
//        public string small { get; set; }
//        public string large { get; set; }
//    }

//    public class Neighborhood_Info
//    {
//        public string location_id { get; set; }
//        public string name { get; set; }
//    }

//}
