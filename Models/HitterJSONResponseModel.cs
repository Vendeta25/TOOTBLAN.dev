using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace MLBApp.Models
{
    class SingleOrArrayConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<T>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                return token.ToObject<List<T>>();
            }
            if(token.ToString() == "")
            {
                return null;
            }
            return new List<T> { token.ToObject<T>() };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            List<T> list = (List<T>)value;
            if (list.Count == 1)
            {
                value = list[0];
            }
            serializer.Serialize(writer, value);
        }

        public override bool CanWrite
        {
            get { return true; }
        }
    }

    public class queryresultsHitter
    {
        [JsonProperty("created")]
        public string created { get; set; }

        [JsonProperty("totalSize")]
        public string totalSize { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<HitterListItemModel>))]
        [JsonProperty("row")]
        public List<HitterListItemModel> row { get; set; }
    }
    public class resultsShellHitter
    {
        public string copyRight { get; set; }
        [JsonProperty("queryResults")]

        public queryresultsHitter queryResults { get; set; }
    }

    public class HitterJSONResponseModel
    {
        [JsonProperty("sport_hitting_tm")]
        public resultsShellHitter response { get; set; }
    }
    public class HitterListItemModel
    {


        public string? gidp { get; set; }
        [JsonProperty("sac")]
        public int? sac { get; set; }
        public string? np { get; set; }
        public string? sport_code { get; set; }
        public string? hgnd { get; set; }
        [JsonProperty("tb")]
        public int? tb { get; set; }
        public string? gidp_opp { get; set; }
        public string? sport_id { get; set; }

        [JsonProperty("bb")]
        public int? bb { get; set; }
        
        [JsonProperty("avg")]
        public double? avg { get; set; }

        [JsonProperty("slg")]
        public double? slg { get; set; }
        public string? team_full { get; set; }

        [JsonProperty("ops")]
        public double? ops { get; set; }
        [JsonProperty("hbp")]
        public int? hbp { get; set; }
        public string? league_full { get; set; }
        public string? team_abbrev { get; set; }
        public string? hpop { get; set; }
        public string? cs { get; set; }
        public string? season { get; set; }
        [JsonProperty("sb")]
        public int? sb { get; set; }
        public string? go_ao { get; set; }
        public string? ppa { get; set; }
        public string? player_id { get; set; }
        [JsonProperty("ibb")]
        public int? ibb { get; set; }
        public string? team_id { get; set; }
        public string? roe { get; set; }
        public string? go { get; set; }
        [JsonProperty("hr")]
        public int? hr { get; set; }
        [JsonProperty("rbi")]
        public int? rbi { get; set; }
        public string? babip { get; set; }
        public string? lob { get; set; }
        public string? end_date { get; set; }
        public string? xbh { get; set; }
        public string? league_short { get; set; }
        [JsonProperty("g")]
        public int? g { get; set; }
        [JsonProperty("d")]
        public int? d { get; set; }
        public string? sport { get; set; }
        public string? team_short { get; set; }
        public string? tpa { get; set; }
        [JsonProperty("h")]
        public int? h { get; set; }
        [JsonProperty("obp")]
        public double? obp { get; set; }
        public string? hldr { get; set; }
        [JsonProperty("t")]
        public int? t { get; set; }
        public string? ao { get; set; }
        public string? r { get; set; }

        [JsonProperty("ab")]
        public int? ab { get; set; }

        [JsonProperty("so")]
        public int? so { get; set; }





    }
}
