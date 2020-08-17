using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MLBApp.Models
{
    public class queryresultsPitcher
    {
        [JsonProperty("created")]
        public string created { get; set; }

        [JsonProperty("totalSize")]
        public string totalSize { get; set; }

        [JsonProperty("row")]
        [JsonConverter(typeof(SingleOrArrayConverter<PitcherListItemModel>))]

        public List<PitcherListItemModel> row { get; set; }
    }
    public class resultsShellPitcher

    {
        public string copyRight { get; set; }
        [JsonProperty("queryResults")]

        public queryresultsPitcher queryResults { get; set; }
    }

    public class PitcherJSONResponseModel
    {
        [JsonProperty("sport_pitching_tm")]
        public resultsShellPitcher response { get; set; }
    }
    public class PitcherListItemModel
    {

        public string gidp { get; set; }

        [JsonProperty("h9")]
        private string h9String { get; set; }

        [JsonProperty("h9Final")]
        public decimal h9
        {
            get
            {
                decimal result;
                if (decimal.TryParse(h9String,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { h9String = value.ToString(); }
        }

        [JsonProperty("sac")]
        public int sac { get; set; }

        public string np { get; set; }

        [JsonProperty("tr")]
        private string trString { get; set; }

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

        [JsonProperty("gf")]
        public int gf { get; set; }

        public string sport_code { get; set; }

        [JsonProperty("bqs")]
        private string bqsString { get; set; }

        [JsonProperty("bqsFinal")]
        public decimal bqs
        {
            get
            {
                decimal result;
                if (decimal.TryParse(bqsString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { bqsString = value.ToString(); }
        }
        public string hgnd { get; set; }

        [JsonProperty("sho")]
        public int sho { get; set; }
        public string bq { get; set; }
        public string gidp_opp { get; set; }
        public string bk { get; set; }
        public string kbb { get; set; }
        public string sport_id { get; set; }

        [JsonProperty("hr9")]
        private string hr9String { get; set; }

        [JsonProperty("hr9Final")]
        public decimal hr9
        {
            get
            {
                decimal result;
                if (decimal.TryParse(hr9String,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { hr9String = value.ToString(); }
        }

        [JsonProperty("sv")]
        public int sv { get; set; }

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

        [JsonProperty("bb")]
        public int bb { get; set; }

        [JsonProperty("whip")]
        private string whipString { get; set; }

        [JsonProperty("whipFinal")]
        public decimal whip
        {
            get
            {
                decimal result;
                if (decimal.TryParse(whipString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { whipString = value.ToString(); }
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
        public string team_full { get; set; }

        [JsonProperty("ops")]
        private string opsString { get; set; }

        [JsonProperty("opsFinal")]
        public decimal ops
        {
            get
            {
                decimal result;
                if (decimal.TryParse(opsString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { opsString = value.ToString(); }
        }

        public string league_full { get; set; }
        public string db { get; set; }

        public string team_abbrev { get; set; }

        [JsonProperty("hfly")]
        private string hflyString { get; set; }

        [JsonProperty("hflyFinal")]
        public int hfly
        {
            get
            {
                int result;
                if (int.TryParse(hflyString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { hflyString = value.ToString(); }
        }

        [JsonProperty("so")]
        public int so { get; set; }

        [JsonProperty("tbf")]
        public int tbf { get; set; }

        [JsonProperty("bb9")]
        private string bb9String { get; set; }

        [JsonProperty("bb9Final")]
        public decimal bb9
        {
            get
            {
                decimal result;
                if (decimal.TryParse(bb9String,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { bb9String = value.ToString(); }
        }
        public string league_id { get; set; }

        [JsonProperty("wp")]
        public int wp { get; set; }

        [JsonProperty("sf")]
        public int sf { get; set; }
        public string team_seq { get; set; }

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
        public string league { get; set; }

        [JsonProperty("hb")]
        public int hb { get; set; }

        [JsonProperty("cs")]
        private string csString { get; set; }

        [JsonProperty("csFinal")]
        public int cs
        {
            get
            {
                int result;
                if (int.TryParse(csString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { csString = value.ToString(); }
        }
        public string pgs { get; set; }
        public string season { get; set; }

        [JsonProperty("sb")]
        private string sbString { get; set; }

        [JsonProperty("sbFinal")]
        public int sb
        {
            get
            {
                int result;
                if (int.TryParse(sbString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { sbString = value.ToString(); }
        }
        public string go_ao { get; set; }
        public string ppa { get; set; }

        [JsonProperty("cg")]
        private string cgString { get; set; }

        [JsonProperty("cgFinal")]
        public int cg
        {
            get
            {
                int result;
                if (int.TryParse(cgString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { cgString = value.ToString(); }
        }
        public string player_id { get; set; }

        [JsonProperty("gs")]
        private string gsString { get; set; }

        [JsonProperty("gsFinal")]
        public int gs
        {
            get
            {
                int result;
                if (int.TryParse(gsString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { gsString = value.ToString(); }
        }

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
        public string team_id { get; set; }
        public string pk { get; set; }
        public string go { get; set; }

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
        public string irs { get; set; }
        public string wpct { get; set; }

        [JsonProperty("era")]
        private string eraString { get; set; }

        [JsonProperty("eraFinal")]
        public decimal era
        {
            get
            {
                decimal result;
                if (decimal.TryParse(eraString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { eraString = value.ToString(); }
        }

        [JsonProperty("babip")]
        public double babip { get; set; }
        public string end_date { get; set; }
        public string rs9 { get; set; }
        public string qs { get; set; }
        public string league_short { get; set; }

        [JsonProperty("g")]
        public int g { get; set; }
        public string ir { get; set; }
        public string hld { get; set; }

        [JsonProperty("k9")]
        private string k9String { get; set; }

        [JsonProperty("k9Final")]
        public decimal k9
        {
            get
            {
                decimal result;
                if (decimal.TryParse(k9String,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { k9String = value.ToString(); }
        }
        public string sport { get; set; }
        public string team_short { get; set; }
        public string l { get; set; }
        public string svo { get; set; }

        [JsonProperty("h")]
        private string hString { get; set; }

        [JsonProperty("hFinal")]
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

        [JsonProperty("ip")]
        private string ipString { get; set; }

        [JsonProperty("ipFinal")]
        public decimal ip
        {
            get
            {
                decimal result;
                if (decimal.TryParse(ipString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { ipString = value.ToString(); }
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
        public string w { get; set; }
        public string hldr { get; set; }
        public string ao { get; set; }
        public string s { get; set; }
        public string r { get; set; }
        public string spct { get; set; }
        public string pip { get; set; }

        [JsonProperty("ab")]
        public int ab { get; set; }

        [JsonProperty("er")]
        private string erString { get; set; }

        [JsonProperty("erFinal")]
        public int er
        {
            get
            {
                int result;
                if (int.TryParse(erString,
                        out result))
                    return result;
                else
                    return 0;
            }
            set { erString = value.ToString(); }
        }



    }
}
