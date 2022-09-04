using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TOOTBLAN.Models
{
    public class PlayerResults
    {
        [JsonProperty("created")]
        public string created { get; set; }

        [JsonProperty("totalSize")]
        public string totalSize { get; set; }

        [JsonProperty("row")]
        [JsonConverter(typeof(SingleOrArrayConverter<Player>))]
        public List<Player> row { get; set; }
    }
    public class PlayerCopyright

    {
        public string copyRight { get; set; }
        [JsonProperty("queryResults")]

        public PlayerResults queryResults { get; set; }
    }

    public class PlayerJSONWrapper
    {
        [JsonProperty("player_info")]
        public PlayerCopyright response { get; set; }
    }
    public class Player
    {

        //public string position_txt { get; set; }
        //public string weight { get; set; }
        //public string name_display_first_last { get; set; }
        //public string college { get; set; }
        //public string height_inches { get; set; }
        //public string starter_sw { get; set; }
        //public string jersey_number { get; set; }
        public string end_date { get; set; }
        //public string name_first { get; set; }
        //public string bats { get; set; }
        //public string team_code { get; set; }
        //public string height_feet { get; set; }
        public string pro_debut_date { get; set; }
        //public string status_code { get; set; }
        //public string primary_position { get; set; }
        //public string birth_date { get; set; }
        //public string team_abbrev { get; set; }
        //public string throws { get; set; }
        //public string team_name { get; set; }
        //public string name_display_last_first { get; set; }
        //public string name_use { get; set; }
        //public string player_id { get; set; }
        //public string name_last { get; set; }
        //public string team_id { get; set; }
        //public string start_date { get; set; }
        //public string name_full { get; set; }
        
    }
}
