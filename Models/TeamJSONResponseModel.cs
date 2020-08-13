using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MLBApp.Models
{
    public class queryresultsTeam
    {
        [JsonProperty("created")]
        public string created { get; set; }

        [JsonProperty("totalSize")]
        public string totalSize { get; set; }

        [JsonProperty("row")]
        public TeamListItemModel[] row { get; set; }
    }
    public class resultsShell
    {
        public string copyRight { get; set; }
        [JsonProperty("queryResults")]

        public queryresultsTeam teamQueryResults { get; set; }
    }

    public class TeamJSONResponseModel
    {
        [JsonProperty("team_all_season")]
        public resultsShell response { get; set; }
    }

    public class TeamListItemModel
    {


        public string phone_number { get; set; }
        public string venue_name { get; set; }
        public string franchise_code { get; set; }
        public string all_star_sw { get; set; }
        public string sport_code { get; set; }
        public string address_city { get; set; }
        public string city { get; set; }
        public string name_display_full { get; set; }
        public string spring_league_abbrev { get; set; }
        public string time_zone_alt { get; set; }
        public string sport_id { get; set; }
        public string venue_id { get; set; }
        public string mlb_org_id { get; set; }
        public string time_zone_generic { get; set; }
        public string mlb_org { get; set; }
        public string last_year_of_play { get; set; }
        public string league_full { get; set; }
        public string home_opener_time { get; set; }
        public string address_province { get; set; }
        public string league_id { get; set; }
        public string name_abbrev { get; set; }
        public string bis_team_code { get; set; }
        public string league { get; set; }
        public string spring_league { get; set; }
        public string base_url { get; set; }
        public string address_zip { get; set; }
        public string sport_code_display { get; set; }
        public string mlb_org_short { get; set; }
        public string time_zone { get; set; }
        public string address_line1 { get; set; }
        public string mlb_org_brief { get; set; }
        public string address_line2 { get; set; }
        public string season { get; set; }
        public string address_line3 { get; set; }
        public string division_abbrev { get; set; }
        public string name_display_short { get; set; }
        public string team_id { get; set; }
        public string active_sw { get; set; }
        public string address_intl { get; set; }
        public string state { get; set; }
        public string address_country { get; set; }
        public string mlb_org_abbrev { get; set; }
        public string division { get; set; }
        public string team_code { get; set; }
        public string name { get; set; }
        public string website_url { get; set; }
        public string sport_code_name { get; set; }
        public string first_year_of_play { get; set; }
        public string league_abbrev { get; set; }
        public string name_display_long { get; set; }
        public string store_url { get; set; }
        public string time_zone_text { get; set; }
        public string name_short { get; set; }
        public string home_opener { get; set; }
        public string address_state { get; set; }
        public string division_full { get; set; }
        public string time_zone_num { get; set; }
        public string spring_league_full { get; set; }
        public string address { get; set; }
        public string name_display_brief { get; set; }
        public string file_code { get; set; }
        public string division_id { get; set; }
        public string spring_league_id { get; set; }
        public string venue_short { get; set; }
    }
}
