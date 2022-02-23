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
    public class DishesController : Controller
    {
        private ChefsNDishesContext db;
        public DishesController(ChefsNDishesContext context)
        {
            db = context;
        }

        [HttpGet("/dishes")]
        public IActionResult Dishes()
        {
            List<Dish> dishes = db.Dishes.Include(d => d.Chef).ToList();
            return View("Dishes", dishes);
        }

        [HttpGet("/dishes/new")]
        public IActionResult NewDish()
        {
            ViewBag.Chefs = db.Chefs.ToList();
            return View("NewDish");
        }

        [HttpPost("/dishes/create")]
        public IActionResult CreateDish(Dish newDish)
        {
            if (!ModelState.IsValid)
            {
                return View("NewDish");
            }
            Chef getChef = db.Chefs.SingleOrDefault(c => c.ChefId == newDish.ChefId);
            newDish.Chef = getChef;
            db.Dishes.Add(newDish);
            db.SaveChanges();
            return RedirectToAction("Dishes");
        }
    }
}