using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleMVCApps.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using MLBApp.Models;

namespace MLBApp.Controllers
{
    
    public class PitchersController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public PitchersController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult GetTeamsForYear(int year)
        {

            var teams = new List<SelectListItem>();
            var url = "http://lookup-service-prod.mlb.com/json/named.team_all_season.bam";
            using (var client = new HttpClient())
            {

                //Passing service base url  
                client.BaseAddress = new Uri(url);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var q = "?sport_code='mlb'&all_star_sw='N'&sort_order='name_asc'&season='" + year +"'";
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                var Res = client.GetAsync(q);
                Res.Wait();
                var result = Res.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readString = result.Content.ReadAsStringAsync().Result;
                    TeamJSONResponseModel teamResponse = JsonConvert.DeserializeObject<TeamJSONResponseModel>(readString);
                    if(teamResponse != null)
                    {
                        teams = teamResponse.response.teamQueryResults.row.Select(t => new SelectListItem
                        {
                            Text = t.name_display_full,
                            Value = t.team_id


                        }).OrderBy(cn => cn.Text).ToList();
                    }

            }

            
            }
            return Json(teams);
        }
    
        public PlayerModel GetPitcherData(string playerId)
        {
            var pitcher = new PlayerModel();
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
                var Res = client.GetAsync(q);
                Res.Wait();
                var result = Res.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readString = result.Content.ReadAsStringAsync().Result;
                    PlayerJSONResponseModel playerResponse = JsonConvert.DeserializeObject<PlayerJSONResponseModel>(readString);
                    if (playerResponse != null)
                    {
                        pitcher = playerResponse.response.queryResults.row[0];
                    }

                }


            }
            return pitcher;
        }

        public JsonResult GetPitchersForTeam(int teamID)
        {
            var players = new List<SelectListItem>();
            var url = "http://lookup-service-prod.mlb.com/json/named.roster_40.bam";
            using (var client = new HttpClient())
            {

                //Passing service base url  
                client.BaseAddress = new Uri(url);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var q = "?team_id='"+ teamID+"'";
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                var Res = client.GetAsync(q);
                Res.Wait();
                var result = Res.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readString = result.Content.ReadAsStringAsync().Result;
                    PlayerListJSONResponseModel playerResponse = JsonConvert.DeserializeObject<PlayerListJSONResponseModel>(readString);
                    if (playerResponse != null)
                    {
                        players = playerResponse.response.queryResults.row.Where(p => p.position_txt == "P").Select(t => new SelectListItem
                        {
                            Text = t.name_full,
                            Value = t.player_id


                        }).OrderBy(cn => cn.Text).ToList();
                    }

                }


            }
            return Json(players);
        }

        public JsonResult GetPlayerData(string playerId)
        {
            var player = GetPitcherData(playerId);
            var debutYear = DateTime.Parse(player.pro_debut_date).Year;
            var data = new List<PitcherListItemModel>();
            int year = DateTime.Today.Year;
            PitcherListItemModel item = new PitcherListItemModel();
            //bool run = true;
            while(year >= debutYear)
            {
                item = GetStatsForYear(year, playerId);
                if(item != null)
                {
                    data.Add(item);
                }
                else
                {
                    data.Add(new PitcherListItemModel() { season = year.ToString() });
                }
                year--;

            };
            data.Reverse();
            return Json(data);
        }

        public PitcherListItemModel GetStatsForYear(int year, string playerID)
        {
            PitcherListItemModel yearData = null;
            var url = "http://lookup-service-prod.mlb.com/json/named.sport_pitching_tm.bam";
            using (var client = new HttpClient())
            {

                //Passing service base url  
                client.BaseAddress = new Uri(url);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var q = "?league_list_id='mlb'&game_type='R'&player_id='" + playerID + "'&season='" + year + "'";
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                var Res = client.GetAsync(q);
                Res.Wait();
                var result = Res.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readString = result.Content.ReadAsStringAsync().Result;
                    PitcherJSONResponseModel statsResponse = JsonConvert.DeserializeObject<PitcherJSONResponseModel>(readString);
                    if (statsResponse != null)
                    {
                        //combine yearly totals for both teams here
                        if(Int64.Parse(statsResponse.response.queryResults.totalSize) > 1)
                        {
                            yearData = CombinePitcherStatsForYear(statsResponse.response.queryResults.row);
                        }
                        //single team for a year
                        else if(Int64.Parse(statsResponse.response.queryResults.totalSize) == 1)
                        {
                            yearData = statsResponse.response.queryResults.row[0];

                        }
                    }


                }

            }

            return yearData;
        }

        private PitcherListItemModel CombinePitcherStatsForYear(List<PitcherListItemModel> stats)
        {
            PitcherListItemModel finalTotals = new PitcherListItemModel();
            foreach(PitcherListItemModel year in stats)
            {
                finalTotals.ab += year.ab;
                finalTotals.bb += year.bb;
                finalTotals.hr += year.hr;
                finalTotals.ibb += year.ibb;
                finalTotals.so += year.so;
                finalTotals.er += year.er;
                finalTotals.ip += year.ip;
                if(finalTotals.ip - Math.Truncate(finalTotals.ip) >= 0.3m)
                {
                    finalTotals.ip += .7m;
                }
                finalTotals.hb += finalTotals.hb;
                finalTotals.h += finalTotals.h;
                finalTotals.season = year.season;
                finalTotals.team_full = finalTotals.team_full;

            }

            double inningsPitched = 0;
            double deci = (double)(finalTotals.ip - Math.Truncate(finalTotals.ip));
            switch (deci)
            {
                case .1:
                    inningsPitched = (double)Math.Truncate(finalTotals.ip) + .33;
                    break;
                case .2:
                    inningsPitched = (double)Math.Truncate(finalTotals.ip) + .66;
                    break;
                case 0:
                    inningsPitched = (double)finalTotals.ip;
                    break;
            }
            finalTotals.k9 = 9 *((float)finalTotals.so / (float)finalTotals.ip);
            finalTotals.obp = (float)(finalTotals.bb + finalTotals.ibb + finalTotals.h + finalTotals.hb) / (finalTotals.ab + finalTotals.ibb + finalTotals.bb + finalTotals.sac);
            finalTotals.whip = (decimal)((finalTotals.bb + finalTotals.h) / inningsPitched);
            finalTotals.era = (float)(finalTotals.er / inningsPitched) * 9;
            finalTotals.avg = Math.Round(finalTotals.avg, 3);
            finalTotals.era = Math.Round(finalTotals.era, 2);
            finalTotals.obp = Math.Round(finalTotals.obp, 3);
            finalTotals.k9 = Math.Round(finalTotals.k9, 2);
            return finalTotals;
        }
    }
}
