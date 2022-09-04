using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace TOOTBLAN.Models
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





    public class HitterResults
    {
        [JsonProperty("created")]
        public string created { get; set; }

        [JsonProperty("totalSize")]
        public string totalSize { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<Hitter>))]
        [JsonProperty("row")]
        public List<Hitter> row { get; set; }
    }
    public class HitterCopyright
    {
        public string copyRight { get; set; }
        [JsonProperty("queryResults")]

        public HitterResults queryResults { get; set; }
    }

    public class HitterJSONWrapper
    {
        [JsonProperty("sport_hitting_tm")]
        public HitterCopyright response { get; set; }
    }
    public class Hitter
    {
        #region Strings
        [JsonProperty("gidp")]
        private string gidp { get; set; }
        [JsonProperty("sac")]
        private string sac { get; set; }
        private string tb { get; set; }
        [JsonProperty("bb")]
        private string bb { get; set; }
        [JsonProperty("avg")]
        private string avg { get; set; }
        [JsonProperty("slg")]
        private string slg { get; set; }
        [JsonProperty("ops")]
        private string ops { get; set; }
        [JsonProperty("hbp")]
        private string hbp { get; set; }
        [JsonProperty("hpop")]
        private string hpop { get; set; }
        [JsonProperty("sb")]
        public string sb { get; set; }
        [JsonProperty("ibb")]
        private string ibb { get; set; }
        [JsonProperty("hr")]
        private string hr { get; set; }
        [JsonProperty("rbi")]
        private string rbi { get; set; }
        [JsonProperty("babip")]
        private string babip { get; set; }
        [JsonProperty("g")]
        private string g { get; set; }
        [JsonProperty("d")]
        private string d { get; set; }
        [JsonProperty("t")]
        private string t { get; set; }
        [JsonProperty("h")]
        private string h { get; set; }
        [JsonProperty("obp")]
        private string obp { get; set; }
        [JsonProperty("r")]
        private string r { get; set; }
        [JsonProperty("ab")]
        private string ab { get; set; }
        [JsonProperty("so")]
        private string so { get; set; }
        [JsonProperty("np")]
        public string np { get; set; }
        [JsonProperty("sport_code")]
        public string sport_code { get; set; }
        [JsonProperty("hgnd")]
        public string hgnd { get; set; }
        [JsonProperty("gidp_opp")]
        public string gidp_opp { get; set; }
        [JsonProperty("sport_id")]
        public string sport_id { get; set; }

        [JsonProperty("team_full")]
        public string team_full { get; set; }
        [JsonProperty("cs")]
        public string cs { get; set; }
        [JsonProperty("season")]
        public string season { get; set; }
        [JsonProperty("go_ao")]
        public string go_ao { get; set; }
        [JsonProperty("ppa")]
        public string ppa { get; set; }
        [JsonProperty("player_id")]
        public string player_id { get; set; }
        [JsonProperty("team_id")]
        public string team_id { get; set; }
        [JsonProperty("roe")]
        public string roe { get; set; }
        [JsonProperty("go")]
        public string go { get; set; }
        [JsonProperty("lob")]
        public string lob { get; set; }
        [JsonProperty("end_date")]
        public string end_date { get; set; }
        [JsonProperty("xbh")]
        public string xbh { get; set; }
        [JsonProperty("league_short")]
        public string league_short { get; set; }
        [JsonProperty("sport")]
        public string sport { get; set; }
        [JsonProperty("team_short")]
        public string team_short { get; set; }
        [JsonProperty("tpa")]
        public string tpa { get; set; }
        [JsonProperty("hldr")]
        public string hldr { get; set; }

        
        #endregion

        #region Values
        [JsonProperty("Ground Into Double Plays")]
        public int GroundIntoDoublePlays { 
            get 
            {
                int result;
                if (int.TryParse(gidp, out result))
                    return result;
                else
                    return 0;
            }
            set { gidp = value.ToString(); }
        }


        [JsonProperty("Sac Flys")]
        public int SacFlys
        {
            get
            {
                int result;
                if (int.TryParse(sac,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { sac = value.ToString(); }
        }


        [JsonProperty("Total Bases")]
        public int TotalBases
        {
            get
            {
                int result;
                if (int.TryParse(tb,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { tb = value.ToString(); }
        }



        [JsonProperty("Walks")]
        public int Walks
        {
            get
            {
                int result;
                if (int.TryParse(bb,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { bb = value.ToString(); }
        }


        [JsonProperty("BattingAverage")]
        public decimal BattingAverage
        {
            get
            {
                decimal result;
                if (decimal.TryParse(avg,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { avg = value.ToString(); }
        }

        

        [JsonProperty("Slugging Percentage")]
        public decimal SluggingPercentage
        {
            get
            {
                decimal result;
                if (decimal.TryParse(slg,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { slg = value.ToString(); }
        }

        

        [JsonProperty("On Base Plus")]
        public decimal OnBasePlus { get {
                decimal result;
                if (decimal.TryParse(ops,
                        out result))
                    return result;
                else
                    return 0;
            } set { ops = value.ToString(); } }

        

        [JsonProperty("Hit by Pitch")]
        public int HitByPitch
        {
            get
            {
                int result;
                if (int.TryParse(hbp,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { hbp = value.ToString(); }
        }


        

        [JsonProperty("High Pops")]
        public int HighPops
        {
            get
            {
                int result;
                if (int.TryParse(hpop,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { hpop = value.ToString(); }
        }


        [JsonProperty("Stolen Bases")]
        public int StolenBases
        {
            get
            {
                int result;
                if (int.TryParse(sb,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { sb = value.ToString(); }
        }

        

        [JsonProperty("Intentional Walks")]
        public int IntentionalWalks
        {
            get
            {
                int result;
                if (int.TryParse(ibb,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { ibb = value.ToString(); }
        }



        [JsonProperty("Home Runs")]
        public int HomeRuns
        {
            get
            {
                int result;
                if (int.TryParse(hr,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { hr = value.ToString(); }
        }

        

        [JsonProperty("Runs Batted In")]
        public int RunsBattedIn
        {
            get
            {
                int result;
                if (int.TryParse(rbi,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { rbi = value.ToString(); }
        }
        

        [JsonProperty("Batting Average Ball In Play")]
        public decimal BattingAverageBallInPlay
        {
            get
            {
                decimal result;
                if (decimal.TryParse(babip,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { babip = value.ToString(); }
        }



        [JsonProperty("Games")]
        public int Games {
            get 
            {
                int result;
                if (int.TryParse(g, out result))
                    return result;
                else
                    return 0;
            }
            set { g = value.ToString(); }
        
        }


        [JsonProperty("Doubles")]
        public int Doubles
        {
            get
            {
                int result;
                if (int.TryParse(d,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { d = value.ToString(); }
        }


        [JsonProperty("Hits")]
        public int Hits
        {
            get
            {
                int result;
                if (int.TryParse(h,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { h = value.ToString(); }
        }


        [JsonProperty("OnBasePercentage")]
        public decimal OnBasePercentage
        {
            get
            {
                decimal result;
                if (decimal.TryParse(obp,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { obp = value.ToString(); }
        }


        

        [JsonProperty("Triples")]
        public int Triples
        {
            get
            {
                int result;
                if (int.TryParse(t,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { t = value.ToString(); }
        }
        public string ao { get; set; }

        [JsonProperty("Runs")]
        public int Runs 
        {
            get 
            {
                int result;
                if (int.TryParse(r, out result))
                    return result;
                else
                    return 0;
            }
            set { r = value.ToString(); }
        }



        [JsonProperty("At Bats")]
        public int AtBats
        {
            get
            {
                int result;
                if (int.TryParse(ab,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { ab = value.ToString(); }
        }




        [JsonProperty("Strike Outs")]
        public int StrikeOuts
        {
            get
            {
                int result;
                if (int.TryParse(so,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { so = value.ToString(); }
        }
        #endregion



    }
}
