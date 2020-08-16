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
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
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

        public IActionResult About()
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

        public PlayerModel GetHitterData(string playerId)
        {
            var hitter = new PlayerModel();
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
                        hitter = playerResponse.response.queryResults.row[0];
                    }

                }


            }
            return hitter;
        }

        public JsonResult GetHittersForTeam(int teamID, int year)
        {
            var players = new List<SelectListItem>();
            var url = "http://lookup-service-prod.mlb.com/json/named.roster_team_alltime.bam";
            using (var client = new HttpClient())
            {

                //Passing service base url  
                client.BaseAddress = new Uri(url);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var q = "?start_season='"+year+"'&end_season='"+ year+"'&team_id='" + teamID+ "'";
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
                        players = playerResponse.response.queryResults.row.Where(p => p.primary_position != "P").Select(t => new SelectListItem
                        {
                            Text = t.player_first_last_html,
                            Value = t.player_id


                        }).OrderBy(cn => cn.Text).ToList();
                    }

                }


            }
            return Json(players);
        }

        public JsonResult GetPlayerData(string playerId)
        {
            var data = new List<HitterListItemModel>();
            var player = GetHitterData(playerId);
            var debutDate = DateTime.Parse(player.pro_debut_date).Year;

            int year = 2020;
            if(player.end_date != "")
            {
                year = DateTime.Parse(player.end_date).Year;
            }
            
            HitterListItemModel item = new HitterListItemModel();
            //bool run = true;
            while(year >= debutDate)
            {
                item = GetStatsForYear(year, playerId);
                if(item != null)
                {
                    data.Add(item);
                }
                else
                {
                    data.Add(new HitterListItemModel() { season = year.ToString() });
                }
                year--;

            };
            data.Reverse();
            return Json(data);
        }

        public HitterListItemModel GetStatsForYear(int year, string playerID)
        {
            HitterListItemModel yearData = null;
            var url = "http://lookup-service-prod.mlb.com/json/named.sport_hitting_tm.bam";
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
                    HitterJSONResponseModel statsResponse = JsonConvert.DeserializeObject<HitterJSONResponseModel>(readString);
                    if (statsResponse != null)
                    {
                        //combine yearly totals for both teams here
                        if(Int64.Parse(statsResponse.response.queryResults.totalSize) > 1)
                        {
                            yearData = CombineHitterStatsForYear(statsResponse.response.queryResults.row);
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

        private HitterListItemModel CombineHitterStatsForYear(List<HitterListItemModel> stats)
        {
            HitterListItemModel finalTotals = new HitterListItemModel() {
                ab = 0,
                bb = 0,
                hr = 0,
                ibb = 0,
                rbi = 0,
                hbp = 0,
                h = 0,
                sac = 0,
                t = 0,
                d = 0,
                so = 0
                



            };
            foreach(HitterListItemModel year in stats)
            {
                finalTotals.ab += year.ab.GetValueOrDefault();
                finalTotals.bb += year.bb.GetValueOrDefault();
                finalTotals.hr += year.hr.GetValueOrDefault();
                finalTotals.ibb += year.ibb.GetValueOrDefault();
                finalTotals.rbi += year.rbi.GetValueOrDefault();
                finalTotals.h += year.h.GetValueOrDefault();
                finalTotals.sac += year.sac.GetValueOrDefault();
                finalTotals.hbp += year.hbp.GetValueOrDefault();
                finalTotals.t += year.t.GetValueOrDefault();
                finalTotals.d += year.d.GetValueOrDefault();
                finalTotals.so += year.so.GetValueOrDefault();
                finalTotals.season = year.season;
                finalTotals.team_full = finalTotals.team_full;


            }
            int s = finalTotals.h.GetValueOrDefault() - (finalTotals.hr.GetValueOrDefault() + finalTotals.t.GetValueOrDefault() + finalTotals.d.GetValueOrDefault());
            finalTotals.avg = (float)finalTotals.h.GetValueOrDefault() / (float)finalTotals.ab.GetValueOrDefault();
            finalTotals.obp = (finalTotals.bb.GetValueOrDefault() + finalTotals.ibb.GetValueOrDefault() + finalTotals.h.GetValueOrDefault() + finalTotals.hbp.GetValueOrDefault()) / (finalTotals.ab.GetValueOrDefault() + finalTotals.ibb.GetValueOrDefault() + finalTotals.bb.GetValueOrDefault() + finalTotals.sac.GetValueOrDefault());
            finalTotals.slg = (s + (finalTotals.d.GetValueOrDefault() * 2) + (finalTotals.t.GetValueOrDefault() * 3) + (finalTotals.hr.GetValueOrDefault() * 4))/finalTotals.ab.GetValueOrDefault();
            finalTotals.ops = finalTotals.obp.GetValueOrDefault() + finalTotals.slg.GetValueOrDefault();

            finalTotals.avg = Math.Round(finalTotals.avg.Value, 3);
            finalTotals.slg = Math.Round(finalTotals.slg.Value, 3);
            finalTotals.ops = Math.Round(finalTotals.ops.Value, 3);
            finalTotals.obp = Math.Round(finalTotals.obp.Value, 3);

            return finalTotals;
        }
    }
}
