using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FARTSLAM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace FARTSLAM.Business
{
    public class StatRetreiver : IStatRetreiver
    {
        public Hitter CombineHitterData(List<Hitter> teams)
        {
            var finalTotals = new Hitter();
            //Aggragate counting stats for each team in a year
            foreach (Hitter year in teams)
            {
                finalTotals.AtBats += year.AtBats;
                finalTotals.Walks += year.Walks;
                finalTotals.HomeRuns += year.HomeRuns;
                finalTotals.IntentionalWalks += year.IntentionalWalks;
                finalTotals.RunsBattedIn += year.RunsBattedIn;
                finalTotals.Hits += year.Hits;
                finalTotals.SacFlys += year.SacFlys;
                finalTotals.HitByPitch += year.HitByPitch;
                finalTotals.Triples += year.Triples;
                finalTotals.Doubles += year.Doubles;
                finalTotals.StrikeOuts += year.StrikeOuts;
                finalTotals.season = year.season;
                finalTotals.Games += year.Games;
                finalTotals.StolenBases += year.StolenBases;
                finalTotals.Runs += year.Runs;
                finalTotals.TotalBases += year.TotalBases;
                finalTotals.HighPops += year.HighPops;
                finalTotals.team_short += year.team_short + " ";
                finalTotals.team_full += year.team_full + " ";


            }
            //singles arnt tracked? WHY
            int singles = finalTotals.Hits - (finalTotals.HomeRuns + finalTotals.Triples + finalTotals.Doubles);

            //calculate advanced stats manually
            finalTotals.BattingAverage = (decimal)finalTotals.Hits / (decimal)finalTotals.AtBats;
            finalTotals.OnBasePercentage = (decimal)(finalTotals.Walks + finalTotals.IntentionalWalks + finalTotals.Hits + finalTotals.HitByPitch) / (finalTotals.AtBats + finalTotals.IntentionalWalks + finalTotals.Walks + finalTotals.SacFlys);
            finalTotals.SluggingPercentage = (decimal)(singles + (finalTotals.Doubles * 2) + (finalTotals.Triples * 3) + (finalTotals.HomeRuns * 4)) / finalTotals.AtBats;
            finalTotals.OnBasePlus = (decimal)finalTotals.OnBasePlus + finalTotals.SluggingPercentage;

            finalTotals.BattingAverage = Math.Round(finalTotals.BattingAverage, 3);
            finalTotals.SluggingPercentage = Math.Round(finalTotals.SluggingPercentage, 3);
            finalTotals.OnBasePercentage = Math.Round(finalTotals.OnBasePercentage, 3);
            finalTotals.OnBasePlus = Math.Round(finalTotals.OnBasePlus, 3);

            return finalTotals;
        }

        public Pitcher CombinePitcherData(List<Pitcher> teams)
        {
            Pitcher finalTotals = new Pitcher();
            foreach (Pitcher year in teams)
            {
                finalTotals.AtBats += year.AtBats;
                finalTotals.Walks += year.Walks;
                finalTotals.HomeRuns += year.HomeRuns;
                finalTotals.IntentionalWalks += year.IntentionalWalks;
                finalTotals.StrikeOuts += year.StrikeOuts;
                finalTotals.EarnedRuns += year.EarnedRuns;
                finalTotals.InningsPitched += year.InningsPitched;
                if (finalTotals.InningsPitched - Math.Truncate(finalTotals.InningsPitched) >= 0.3m)
                {
                    finalTotals.InningsPitched += .7m;
                }
                finalTotals.HitBatters += year.HitBatters;
                finalTotals.Hits += year.Hits;
                finalTotals.season = year.season;
                finalTotals.Wins += year.Wins;
                finalTotals.team_short += year.team_short + " ";
                finalTotals.team_full += year.team_full + " ";
                
            }

            //Gotta calculate innings pitched for advanced stat calculations. MLB uses .1 and .2 to denote outs in an inning and not 1/3 and 2/3, so IP cannot be used raw.
            double inningsPitched = 0;
            double deci = (double)(finalTotals.InningsPitched - Math.Truncate(finalTotals.InningsPitched));
            switch (deci)
            {
                case .1:
                    inningsPitched = (double)Math.Truncate(finalTotals.InningsPitched) + .33;
                    break;
                case .2:
                    inningsPitched = (double)Math.Truncate(finalTotals.InningsPitched) + .66;
                    break;
                case 0:
                    inningsPitched = (double)finalTotals.InningsPitched;
                    break;
            }
            finalTotals.OnBasePercentage = (decimal)((finalTotals.Walks + finalTotals.IntentionalWalks + finalTotals.Hits + finalTotals.HitBatters) / (finalTotals.AtBats + finalTotals.IntentionalWalks + finalTotals.Walks + finalTotals.SacFlys));
            finalTotals.WHIP = (decimal)((finalTotals.Walks + finalTotals.Hits) / inningsPitched);
            finalTotals.EarnedRunAverage = 9 * (decimal)(finalTotals.EarnedRuns / inningsPitched);
            finalTotals.HomeRunsPer9 = 9 * (decimal)(finalTotals.HomeRuns / inningsPitched);
            finalTotals.WalksPer9 = 9 * (decimal)(finalTotals.Walks / inningsPitched);
            finalTotals.StrikeOutsPer9 = 9 * (decimal)(finalTotals.StrikeOuts / finalTotals.InningsPitched);
            finalTotals.HitsPer9 = 9 * (decimal)(finalTotals.Hits / inningsPitched);
           
            finalTotals.BattingAverage = Math.Round(finalTotals.BattingAverage, 3);
            finalTotals.EarnedRunAverage = Math.Round(finalTotals.EarnedRunAverage, 2);
            finalTotals.OnBasePercentage = Math.Round(finalTotals.OnBasePercentage, 3);
            finalTotals.StrikeOutsPer9 = Math.Round(finalTotals.StrikeOutsPer9, 2);
            finalTotals.HitsPer9 = Math.Round(finalTotals.HitsPer9, 2);
            finalTotals.WalksPer9 = Math.Round(finalTotals.WalksPer9, 2);
            finalTotals.HomeRunsPer9 = Math.Round(finalTotals.HomeRunsPer9, 2);

            return finalTotals;
        }

        public async Task<List<Hitter>> GetHitterData(int playerId, int year)
        {
            List<Hitter> yearData = new List<Hitter>();
            var url = "http://lookup-service-prod.mlb.com/json/named.sport_hitting_tm.bam";
            using (var client = new HttpClient())
            {

                //Passing service base url  
                client.BaseAddress = new Uri(url);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var q = "?league_list_id='mlb'&game_type='R'&player_id='" + playerId + "'&season='" + year + "'";
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                var result = await client.GetAsync(q);
                if (result.IsSuccessStatusCode)
                {
                    var readString = result.Content.ReadAsStringAsync().Result;
                    var statsResponse = JsonConvert.DeserializeObject<HitterJSONWrapper>(readString);
                    if (statsResponse != null)
                    {
                        yearData = statsResponse.response.queryResults.row;
                    }
                    else
                    {
                        yearData.Add(new Hitter() { season = year.ToString(), team_short = "DNP" });
                    }


                }

            }

            return yearData;
        }

        public async Task<List<Pitcher>> GetPitcherData(int playerId, int year)
        {
            List<Pitcher> yearData = null;
            var url = "http://lookup-service-prod.mlb.com/json/named.sport_pitching_tm.bam";
            using (var client = new HttpClient())
            {

                //Passing service base url  
                client.BaseAddress = new Uri(url);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var q = "?league_list_id='mlb'&game_type='R'&player_id='" + playerId + "'&season='" + year + "'";
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                var result = await client.GetAsync(q);
                if (result.IsSuccessStatusCode)
                {
                    var readString = result.Content.ReadAsStringAsync().Result;
                    var statsResponse = JsonConvert.DeserializeObject<PitcherJSONWrapper>(readString);
                    if (statsResponse != null)
                    {
                        yearData = statsResponse.response.queryResults.row;
                    }


                }

            }

            return yearData;
        }

        public async Task<Player> GetPlayer(int playerId)
        {
            var player = new Player();
            var url = "http://lookup-service-prod.mlb.com/json/named.player_info.bam";
            using (var client = new HttpClient())
            {

                //Passing service base url  
                client.BaseAddress = new Uri(url);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var q = "?sport_code='mlb'&player_id='" + playerId + "'";
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                var result = await client.GetAsync(q);
                if (result.IsSuccessStatusCode)
                {
                    var readString = result.Content.ReadAsStringAsync().Result;
                    var playerResponse = JsonConvert.DeserializeObject<PlayerJSONWrapper>(readString);
                    if (playerResponse != null)
                    {
                        player = playerResponse.response.queryResults.row[0];
                    }

                }


            }
            return player;
        }

        public async Task<List<PlayerListItem>> GetPlayersForTeam(int teamId, int year, bool pitcher)
        {
            var players = new List<PlayerListItem>();
            var url = "http://lookup-service-prod.mlb.com/json/named.roster_team_alltime.bam";
            using (var client = new HttpClient())
            {

                //Passing service base url  
                client.BaseAddress = new Uri(url);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var q = "?start_season='" + year + "'&end_season='" + year + "'&team_id='" + teamId + "'";
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                var result = await client.GetAsync(q);
                if (result.IsSuccessStatusCode)
                {
                    var readString = result.Content.ReadAsStringAsync().Result;
                    var playerResponse = JsonConvert.DeserializeObject<PlayerListJSONWrapper>(readString);
                    if (playerResponse != null)
                    {
                        if (pitcher)
                            players = playerResponse.response.queryResults.row.Where(p => p.primary_position == "P").ToList();
                        else
                            players = playerResponse.response.queryResults.row.Where(p => p.primary_position != "P").ToList();

                    }

                }


            }
            return players;
        }

        public async Task<List<TeamListItem>> GetTeamsForYear(int year)
        {
            var teams = new List<TeamListItem>();
            var url = "http://lookup-service-prod.mlb.com/json/named.team_all_season.bam";
            using (var client = new HttpClient())
            {

                //Passing service base url  
                client.BaseAddress = new Uri(url);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var q = "?sport_code='mlb'&all_star_sw='N'&sort_order='name_asc'&season='" + year + "'";
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                var result =  await client.GetAsync(q);
                if (result.IsSuccessStatusCode)
                {
                    var readString = result.Content.ReadAsStringAsync().Result;
                    var teamResponse = JsonConvert.DeserializeObject<TeamListJSONWrapper>(readString);
                    if (teamResponse != null)
                    {
                        teams = teamResponse.response.queryResults.row;
                    }

                }


            }

            return teams;


        }
    }
}
