using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChefsNDishes.Models;

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
        public IActionResult Index()
        {
            

            return View();
        }
    }
}