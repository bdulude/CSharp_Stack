using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private ChefsNDishesContext db;
        public HomeController(ChefsNDishesContext context)
        {
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> chefs = db.Chefs.Include(c => c.CreatedDishes).ToList();
            return View("Index", chefs);
        }

        [HttpGet("/new")]
        public IActionResult NewChef()
        {
            return View("NewChef");
        }

        [HttpPost("/create")]
        public IActionResult CreateChef(Chef newChef)
        {
            if (!ModelState.IsValid)
            {
                return View("NewChef");
            }
            db.Chefs.Add(newChef);
            db.SaveChanges();
            return RedirectToAction("Index");
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
    }
}
