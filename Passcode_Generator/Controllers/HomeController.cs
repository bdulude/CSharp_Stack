using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Passcode_Generator.Models;
using Microsoft.AspNetCore.Http;

namespace Passcode_Generator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            int? number = HttpContext.Session.GetInt32("number");
            HttpContext.Session.SetInt32("number", number == null ? default(int) + 1 : number.Value + 1);
            ViewBag.number = HttpContext.Session.GetInt32("number");
            ViewBag.passcode = GeneratePW();
            return View();
        }

        private string GeneratePW()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890~! @#$%^&*";
            Random rand = new Random();
            String output = "";
            for (int x = 0; x < 14; x++)
            {
                output = output + chars[rand.Next(0,72)];
            }
            return output;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
