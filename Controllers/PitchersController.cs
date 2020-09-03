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
using FARTSLAM.Models;
using FARTSLAM.Business;

namespace FARTSLAM.Controllers
{

    public class PitchersController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStatRetreiver _stats;

        public PitchersController(ILogger<HomeController> logger, IStatRetreiver stats)
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


        public async Task<JsonResult> GetPitchersForTeam(int teamId, int year)
        {
            var players = await _stats.GetPlayersForTeam(teamId, year, true);
            var list = players.Select(p => new SelectListItem
            {
                Text = p.player_first_last_html,
                Value = p.player_id
            }).OrderBy(p => p.Text);
            return Json(list);
        }

        public async Task<JsonResult> GetPitcherData(int playerId)
        {
            var player = await _stats.GetPlayer(playerId);
            var debutYear = DateTime.Parse(player.pro_debut_date).Year;
            var data = new List<Pitcher>();
            int year = 2020;
            if (player.end_date != "")
            {
                year = DateTime.Parse(player.end_date).Year;
            }

            var result = new List<Pitcher>();
            while (year >= debutYear)
            {
                result = await _stats.GetPitcherData(playerId, year);
                if (result != null)
                {
                    if (result.Count > 1)
                        data.Add(_stats.CombinePitcherData(result));
                    else
                        data.Add(result.FirstOrDefault());
                }
                else
                {
                    data.Add(new Pitcher() { season = year.ToString(), team_short = "Out for Season" });
                }
                year--;

            };
            data.Reverse();
            return Json(data);
        }
    }
}
