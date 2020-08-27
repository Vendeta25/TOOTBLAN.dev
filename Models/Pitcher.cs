using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FARTSLAM.Models
{
    public class PitcherResults
    {
        [JsonProperty("created")]
        public string created { get; set; }

        [JsonProperty("totalSize")]
        public string totalSize { get; set; }

        [JsonProperty("row")]
        [JsonConverter(typeof(SingleOrArrayConverter<Pitcher>))]

        public List<Pitcher> row { get; set; }
    }
    public class PitcherCopyright

    {
        public string copyRight { get; set; }
        [JsonProperty("queryResults")]

        public PitcherResults queryResults { get; set; }
    }

    public class PitcherJSONWrapper
    {
        [JsonProperty("sport_pitching_tm")]
        public PitcherCopyright response { get; set; }
    }
    public class Pitcher
    {
        #region Strings
        [JsonProperty("gidp")]
        public string gidp { get; set; }

        [JsonProperty("h9")]
        private string h9 { get; set; }

        [JsonProperty("sac")]
        public string sac { get; set; }

        [JsonProperty("np")]
        public string np { get; set; }

        [JsonProperty("tr")]
        private string trString { get; set; }
        public string hgnd { get; set; }

        [JsonProperty("sho")]
        public string sho { get; set; }
        public string bq { get; set; }
        public string gidp_opp { get; set; }
        public string bk { get; set; }
        public string kbb { get; set; }
        public string sport_id { get; set; }

        [JsonProperty("hr9")]
        private string hr9 { get; set; }

        [JsonProperty("gf")]
        public string gf { get; set; }

        public string sport_code { get; set; }

        [JsonProperty("bqs")]
        private string bqs { get; set; }








        [JsonProperty("babip")]
        public string babip { get; set; }
        public string end_date { get; set; }
        public string rs9 { get; set; }
        public string qs { get; set; }
        public string league_short { get; set; }

        [JsonProperty("g")]
        public string g { get; set; }
        public string ir { get; set; }
        public string hld { get; set; }

        [JsonProperty("k9")]
        private string k9 { get; set; }
        public string sport { get; set; }
        public string team_short { get; set; }
        public string l { get; set; }
        public string svo { get; set; }

        [JsonProperty("h")]
        private string h { get; set; }

        [JsonProperty("ip")]
        private string ip { get; set; }

        [JsonProperty("obp")]
        private string obp { get; set; }

        [JsonProperty("sv")]
        public string sv { get; set; }

        [JsonProperty("slg")]
        private string slg { get; set; }
        [JsonProperty("bb")]
        public string bb { get; set; }

        [JsonProperty("whip")]
        private string whip { get; set; }

        [JsonProperty("avg")]
        private string avg { get; set; }
        public string team_full { get; set; }

        [JsonProperty("ops")]
        private string ops { get; set; }
        public string league_full { get; set; }
        public string db { get; set; }
        public string team_abbrev { get; set; }

        [JsonProperty("hfly")]
        private string hfly { get; set; }

        [JsonProperty("so")]
        private string so { get; set; }

        [JsonProperty("tbf")]
        public string tbf { get; set; }

        [JsonProperty("bb9")]
        private string bb9 { get; set; }
        public string league_id { get; set; }

        [JsonProperty("wp")]
        public string wp { get; set; }

        [JsonProperty("sf")]
        public int sf { get; set; }
        public string team_seq { get; set; }

        [JsonProperty("hpop")]
        private string hpop { get; set; }

        public string league { get; set; }

        [JsonProperty("hb")]
        public string hb { get; set; }

        [JsonProperty("cs")]
        private string cs { get; set; }

        public string pgs { get; set; }
        public string season { get; set; }

        [JsonProperty("sb")]
        private string sb { get; set; }

        public string go_ao { get; set; }
        public string ppa { get; set; }

        [JsonProperty("cg")]
        private string cg { get; set; }

        public string player_id { get; set; }

        [JsonProperty("gs")]
        private string gs { get; set; }

        [JsonProperty("ibb")]
        private string ibb { get; set; }
        public string team_id { get; set; }
        public string pk { get; set; }
        public string go { get; set; }

        [JsonProperty("hr")]
        private string hr { get; set; }

        public string irs { get; set; }
        public string wpct { get; set; }

        [JsonProperty("era")]
        private string era { get; set; }
        private string w { get; set; }
        public string hldr { get; set; }
        public string ao { get; set; }
        public string s { get; set; }
        public string r { get; set; }
        public string spct { get; set; }
        public string pip { get; set; }

        [JsonProperty("ab")]
        public string ab { get; set; }

        [JsonProperty("er")]
        private string er { get; set; }




        #endregion



        public decimal HitsPer9
        {
            get
            {
                decimal result;
                if (decimal.TryParse(h9,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { h9 = value.ToString(); }
        }


        [JsonProperty("trFinal")]
        public decimal tr
        {
            get
            {
                decimal result;
                if (decimal.TryParse(trString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { trString = value.ToString(); }
        }

        

        

        [JsonProperty("HomeRunsPer9")]
        public decimal HomeRunsPer9
        {
            get
            {
                decimal result;
                if (decimal.TryParse(hr9,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { hr9 = value.ToString(); }
        }

        [JsonProperty("Saves")]
        public int Saves {
            get
            {
                int result;
                if (int.TryParse(sv, out result))
                    return result;
                else
                    return 0;
            }
            set { sv = value.ToString(); }
            
        }

        [JsonProperty("Sac Flys")]
        public int SacFlys
        {
            get
            {
                int result;
                if (int.TryParse(sac, out result))
                    return result;
                else
                    return 0;
            }
            set { sac = value.ToString(); }

        }

        [JsonProperty("SluggingPercentage")]
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

        [JsonProperty("Walks")]
        public int Walks {
            get 
            {
                int result;
                if (int.TryParse(bb, out result))
                    return result;
                else
                    return 0;
            }
            set { bb = value.ToString(); }
        }

        [JsonProperty("At Bats")]
        public int AtBats
        {
            get
            {
                int result;
                if (int.TryParse(ab, out result))
                    return result;
                else
                    return 0;
            }
            set { ab = value.ToString(); }
        }

        [JsonProperty("Hit Batters")]
        public int HitBatters
        {
            get
            {
                int result;
                if (int.TryParse(hb, out result))
                    return result;
                else
                    return 0;
            }
            set { hb = value.ToString(); }
        }

        [JsonProperty("WHIP")]
        public decimal WHIP
        {
            get
            {
                decimal result;
                if (decimal.TryParse(whip,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { whip = value.ToString(); }
        }

        

        [JsonProperty("Batting Average")]
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

        [JsonProperty("On Base Plus")]
        public decimal OnBasePlus
        {
            get
            {
                decimal result;
                if (decimal.TryParse(ops,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { ops = value.ToString(); }
        }

        [JsonProperty("High Flys")]
        public int HighFlys
        {
            get
            {
                int result;
                if (int.TryParse(hfly,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { hfly = value.ToString(); }
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

        [JsonProperty("Walks Per 9")]
        public decimal WalksPer9
        {
            get
            {
                decimal result;
                if (decimal.TryParse(bb9,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { bb9 = value.ToString(); }
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
        

        [JsonProperty("Caught Stealing")]
        public int CaughtStealing
        {
            get
            {
                int result;
                if (int.TryParse(cs,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { cs = value.ToString(); }
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

        [JsonProperty("Complete Games")]
        public int CompleteGames
        {
            get
            {
                int result;
                if (int.TryParse(cg,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { cg = value.ToString(); }
        }
        

        [JsonProperty("Games Started")]
        public int GamesStarted
        {
            get
            {
                int result;
                if (int.TryParse(gs,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { gs = value.ToString(); }
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

        [JsonProperty("EarnedRunAverage")]
        public decimal EarnedRunAverage
        {
            get
            {
                decimal result;
                if (decimal.TryParse(era,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { era = value.ToString(); }
        }


        [JsonProperty("Strike Outs Per 9")]
        public decimal StrikeOutsPer9
        {
            get
            {
                decimal result;
                if (decimal.TryParse(k9,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { k9 = value.ToString(); }
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

        [JsonProperty("Innings Pitched")]
        public decimal InningsPitched
        {
            get
            {
                decimal result;
                if (decimal.TryParse(ip,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { ip = value.ToString(); }
        }

        [JsonProperty("On Base Percentage")]
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

        [JsonProperty("Wins")]
        public int Wins
        {
            get
            {
                int result;
                if (int.TryParse(w,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { w = value.ToString(); }
        }


        [JsonProperty("Earned Runs")]
        public int EarnedRuns
        {
            get
            {
                int result;
                if (int.TryParse(er,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { er = value.ToString(); }
        }



    }
}
