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
using TOOTBLAN.Models;
using TOOTBLAN.Business;

namespace TOOTBLAN.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStatRetreiver _stats;


        public HomeController(ILogger<HomeController> logger, IStatRetreiver stats)
        {
            _logger = logger;
            _stats = stats;
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

        public async Task<JsonResult> GetTeamsForYear(int year)
        {

            var teams = await _stats.GetTeamsForYear(year);
            var list = teams.Select(team => new SelectListItem
            {
                Value = team.team_id,
                Text = team.name_display_full
            }).OrderBy(team => team.Text);
            return Json(list);
        }



        public async Task<JsonResult> GetHittersForTeam(int teamId, int year)
        {
            var players = await _stats.GetPlayersForTeam(teamId, year, false);
            var list = players.Select(p => new SelectListItem
            {
                Text = p.player_first_last_html,
                Value = p.player_id
            }).OrderBy(p => p.Text);
            return Json(list);
        }

        public async Task<JsonResult> GetHitterData(int playerId)
        {
            var player = await _stats.GetPlayer(playerId);
            var debutDate = DateTime.Parse(player.pro_debut_date).Year;

            int year = 2020;
            if (player.end_date != "")
            {
                year = DateTime.Parse(player.end_date).Year;
            }

            List<Hitter> data = new List<Hitter>();

            List<Hitter> item = new List<Hitter>();

            while (year >= debutDate)
            {
                item = await _stats.GetHitterData(playerId, year);
                if (item != null)
                {
                    if(item.Count > 1)
                    {
                        Hitter combinedStats = _stats.CombineHitterData(item);
                        data.Add(combinedStats);
                    }
                    else
                    {
                        data.Add(item.FirstOrDefault());
                    }
                }
                
                year--;

            };
            data.Reverse();
            return Json(data);

        }

        

        
    }
}
