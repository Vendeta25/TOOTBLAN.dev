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
        public double h9 { get; set; }

        [JsonProperty("sac")]
        public int sac { get; set; }

        public string np { get; set; }

        [JsonProperty("tr")]
        public int tr { get; set; }

        [JsonProperty("gf")]
        public int gf { get; set; }

        public string sport_code { get; set; }

        [JsonProperty("bqs")]
        public int bqs { get; set; }
        public string hgnd { get; set; }

        [JsonProperty("sho")]
        public int sho { get; set; }
        public string bq { get; set; }
        public string gidp_opp { get; set; }
        public string bk { get; set; }
        public string kbb { get; set; }
        public string sport_id { get; set; }

        [JsonProperty("hr9")]
        public double hr9 { get; set; }

        [JsonProperty("sv")]
        public int sv { get; set; }

        [JsonProperty("slg")]
        public decimal slg { get; set; }

        [JsonProperty("bb")]
        public int bb { get; set; }

        [JsonProperty("whip")]
        public decimal whip { get; set; }

        [JsonProperty("avg")]
        public decimal avg { get; set; }
        public string team_full { get; set; }

        [JsonProperty("ops")]
        public double ops { get; set; }

        public string league_full { get; set; }
        public string db { get; set; }

        public string team_abbrev { get; set; }

        [JsonProperty("hfly")]
        public int hfly { get; set; }

        [JsonProperty("so")]
        public int so { get; set; }

        [JsonProperty("tbf")]
        public int tbf { get; set; }

        [JsonProperty("bb9")]
        public double bb9 { get; set; }
        public string league_id { get; set; }

        [JsonProperty("wp")]
        public int wp { get; set; }

        [JsonProperty("sf")]
        public int sf { get; set; }
        public string team_seq { get; set; }

        [JsonProperty("hpop")]
        public int hpop { get; set; }
        public string league { get; set; }

        [JsonProperty("hb")]
        public int hb { get; set; }

        [JsonProperty("cs")]
        public int cs { get; set; }
        public string pgs { get; set; }
        public string season { get; set; }

        [JsonProperty("sb")]
        public int sb { get; set; }
        public string go_ao { get; set; }
        public string ppa { get; set; }

        [JsonProperty("cg")]
        public int cg { get; set; }
        public string player_id { get; set; }
        public string gs { get; set; }

        [JsonProperty("ibb")]
        public int ibb { get; set; }
        public string team_id { get; set; }
        public string pk { get; set; }
        public string go { get; set; }

        [JsonProperty("hr")]
        public int hr { get; set; }
        public string irs { get; set; }
        public string wpct { get; set; }

        [JsonProperty("era")]
        public double era { get; set; }

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
        public double k9 { get; set; }
        public string sport { get; set; }
        public string team_short { get; set; }
        public string l { get; set; }
        public string svo { get; set; }

        [JsonProperty("h")]
        public int h { get; set; }

        [JsonProperty("ip")]
        public decimal ip { get; set; }

        [JsonProperty("obp")]
        public double obp { get; set; }
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
        public int er { get; set; }



    }
}
