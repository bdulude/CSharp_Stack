using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomensLeagues = _context.Leagues
            .Where(l => l.Name.Contains("Womens")).ToList();

            ViewBag.HockeyLeagues = _context.Leagues
            .Where(h => h.Sport.Contains("Hockey")).ToList();

            ViewBag.NotFootball = _context.Leagues
            .Where(n => n.Sport != "Football").ToList();

            ViewBag.Conferences = _context.Leagues
            .Where(c => c.Name.Contains("Conference")).ToList();

            ViewBag.AtlanticRegion = _context.Leagues
            .Where(a => a.Name.Contains("Atlantic")).ToList();

            ViewBag.DallasTeams = _context.Teams
            .Where(s => s.Location == "Dallas").ToList();

            ViewBag.Raptors = _context.Teams
            .Where(s => s.TeamName.Contains("Raptors")).ToList();

            ViewBag.Cities = _context.Teams
            .Where(ci => ci.Location.Contains("City")).ToList();

            ViewBag.TTeams = _context.Teams
            .Where(t => t.TeamName.Substring(0,1) == "T").ToList();

            // ViewBag.TTeams = _context.Teams
            // .Where(t => t.TeamName[0] == 'T').ToList();

            ViewBag.Alpha = _context.Teams.OrderBy(al => al.Location);

            ViewBag.Reverse = _context.Teams.OrderByDescending(r => r.TeamName);

            ViewBag.Coopers = _context.Players
            .Where(t => t.LastName == "Cooper").ToList();

            ViewBag.Joshuas = _context.Players
            .Where(j => j.FirstName == "Joshua").ToList();

            ViewBag.CoopersNotJoshua = _context.Players
            .Where(cj => (cj.LastName == "Cooper") && !(cj.FirstName == "Joshua"))
            .ToList();

            ViewBag.AlexanderWyatts = _context.Players
            .Where(aw => (aw.FirstName == "Alexander") || (aw.FirstName == "Wyatt"))
            .ToList();


            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}