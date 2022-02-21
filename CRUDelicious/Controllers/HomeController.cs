using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CRUDelicious.Models;


namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private CRUDeliciousContext db;

        public HomeController(CRUDeliciousContext context)
        {
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.AllDishes = db.Dishes.OrderByDescending(d => d.CreatedAt);
            return View();
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View("new");
        }

        [HttpPost("create")]
        public IActionResult CreateDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                db.Dishes.Add(newDish);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else 
            {
                return View("new");
            }
        }

        [HttpGet("/{dishId}")]
        public IActionResult ReadDish(int dishId)
        {
            Dish RetrievedDish = db.Dishes.SingleOrDefault(d => d.DishId == dishId);
            if (RetrievedDish != null)
            {
                ViewBag.RetrievedDish = RetrievedDish;
                return View("read");
            }
            return RedirectToAction("Index");
        }

        [HttpGet("edit/{dishId}")]
        public IActionResult EditDish(int dishId)
        {
            Dish RetrievedDish = db.Dishes.SingleOrDefault(d => d.DishId == dishId);
            if (RetrievedDish != null)
            {
                ViewBag.RetrievedDish = RetrievedDish;
                return View("edit");
            }
            return RedirectToAction("Index");
        }

        [HttpPost("update")]
        public IActionResult UpdateDish(Dish updateDish)
        {
            if (ModelState.IsValid)
            {
                Dish RetrievedDish = db.Dishes.SingleOrDefault(d => d.DishId == updateDish.DishId);
                RetrievedDish.Name = updateDish.Name;
                RetrievedDish.Chef = updateDish.Chef;
                RetrievedDish.Tastiness = updateDish.Tastiness;
                RetrievedDish.Calories = updateDish.Calories;
                RetrievedDish.Description = updateDish.Description;
                RetrievedDish.UpdatedAt = DateTime.Now;
                // db.Update(updateDish);
                db.SaveChanges();
                return Redirect("/");
            }
            else
            {
                return View("edit");
            }
        }

        [HttpGet("delete/{dishId}")]
        public IActionResult DeleteDish(int dishId)
        {
            Dish RetrievedDish = db.Dishes.SingleOrDefault(d => d.DishId == dishId);
            if (RetrievedDish != null)
            {
                db.Dishes.Remove(RetrievedDish);
                db.SaveChanges();
            }
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
