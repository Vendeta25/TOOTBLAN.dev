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
        private string sacString { get; set; }

        [JsonProperty("sacFinal")]
        public int sac
        {
            get
            {
                int result;
                if (int.TryParse(sacString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { sacString = value.ToString(); }
        }
        public string? np { get; set; }
        public string? sport_code { get; set; }
        public string? hgnd { get; set; }

        [JsonProperty("tb")]
        public int? tb { get; set; }
        public string? gidp_opp { get; set; }
        public string? sport_id { get; set; }

        [JsonProperty("bb")]
        private string bbString { get; set; }

        [JsonProperty("bbFinal")]
        public int bb
        {
            get
            {
                int result;
                if (int.TryParse(bbString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { bbString = value.ToString(); }
        }

        [JsonProperty("avg")]
        private string avgString { get; set; }
        [JsonProperty("avgFinal")]
        public decimal avg
        {
            get
            {
                decimal result;
                if (decimal.TryParse(avgString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { avgString = value.ToString(); }
        }

        [JsonProperty("slg")]
        private string slgString { get; set; }

        [JsonProperty("slgFinal")]
        public decimal slg
        {
            get
            {
                decimal result;
                if (decimal.TryParse(slgString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { slgString = value.ToString(); }
        }
        public string? team_full { get; set; }

        [JsonProperty("ops")]
        private string opsString { get; set; }

        [JsonProperty("opsFinal")]
        public decimal ops { get {
                decimal result;
                if (decimal.TryParse(opsString,
                        out result))
                    return result;
                else
                    return 0;
            } set { opsString = value.ToString(); } }

        [JsonProperty("hbp")]
        private string hbpString { get; set; }

        [JsonProperty("hbpFinal")]
        public int hbp
        {
            get
            {
                int result;
                if (int.TryParse(hbpString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { hbpString = value.ToString(); }
        }
        public string? league_full { get; set; }
        public string? team_abbrev { get; set; }

        [JsonProperty("hpop")]
        private string hpopString { get; set; }

        [JsonProperty("hpopFinal")]
        public int hpop
        {
            get
            {
                int result;
                if (int.TryParse(hpopString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { hpopString = value.ToString(); }
        }
        public string? cs { get; set; }
        public string? season { get; set; }
        [JsonProperty("sb")]
        public int? sb { get; set; }
        public string? go_ao { get; set; }
        public string? ppa { get; set; }
        public string? player_id { get; set; }

        [JsonProperty("ibb")]
        private string ibbString { get; set; }

        [JsonProperty("ibbFinal")]
        public int ibb
        {
            get
            {
                int result;
                if (int.TryParse(ibbString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { ibbString = value.ToString(); }
        }

        public string? team_id { get; set; }
        public string? roe { get; set; }
        public string? go { get; set; }

        [JsonProperty("hr")]
        private string hrString { get; set; }

        [JsonProperty("hrFinal")]
        public int hr
        {
            get
            {
                int result;
                if (int.TryParse(hrString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { hrString = value.ToString(); }
        }

        [JsonProperty("rbi")]
        private string rbiString { get; set; }

        [JsonProperty("rbiFinal")]
        public int rbi
        {
            get
            {
                int result;
                if (int.TryParse(rbiString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { rbiString = value.ToString(); }
        }
        public string? babip { get; set; }
        public string? lob { get; set; }
        public string? end_date { get; set; }
        public string? xbh { get; set; }
        public string? league_short { get; set; }
        [JsonProperty("g")]
        public int? g { get; set; }

        [JsonProperty("d")]
        private string dString { get; set; }

        [JsonProperty("dFinal")]
        public int d
        {
            get
            {
                int result;
                if (int.TryParse(dString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { dString = value.ToString(); }
        }
        public string? sport { get; set; }
        public string? team_short { get; set; }
        public string? tpa { get; set; }

        [JsonProperty("h")]
        private string hString { get; set; }

        [JsonProperty("hbFinal")]
        public int h
        {
            get
            {
                int result;
                if (int.TryParse(hString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { hString = value.ToString(); }
        }

        [JsonProperty("obp")]
        private string obpString { get; set; }

        [JsonProperty("obpFinal")]
        public decimal obp
        {
            get
            {
                decimal result;
                if (decimal.TryParse(obpString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { obpString = value.ToString(); }
        }

        public string? hldr { get; set; }

        [JsonProperty("t")]
        private string tString { get; set; }

        [JsonProperty("tFinal")]
        public int t
        {
            get
            {
                int result;
                if (int.TryParse(tString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { tString = value.ToString(); }
        }
        public string? ao { get; set; }
        public string? r { get; set; }

        [JsonProperty("ab")]
        private string abString { get; set; }

        [JsonProperty("abFinal")]
        public int ab
        {
            get
            {
                int result;
                if (int.TryParse(abString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { abString = value.ToString(); }
        }

        [JsonProperty("so")]
        private string soString { get; set; }

        [JsonProperty("soFinal")]
        public int so
        {
            get
            {
                int result;
                if (int.TryParse(soString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { soString = value.ToString(); }
        }





    }
}
