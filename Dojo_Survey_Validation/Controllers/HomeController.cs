using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dojo_Survey_Validation.Models;

namespace Dojo_Survey_Validation.Controllers
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
            return View("Index");
        }
        [HttpPost("/submit")]
        public IActionResult Submit(Survey submitted)
        {
            if (ModelState.IsValid)
            {
                // HttpContext.Session.SetString("Name", submitted.Name);
                return RedirectToAction("Result", submitted);
            }
            return View("Index");
        }
        [HttpGet("/result")]
        public IActionResult Result(Survey submitted)
        {
            return View("Results", submitted);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
