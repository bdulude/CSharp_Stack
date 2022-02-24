using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wedding_Planner.Models;

namespace Wedding_Planner.Controllers
{
    public class HomeController : Controller
    {
        private Wedding_PlannerContext db;
        public HomeController(Wedding_PlannerContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                return Redirect("/wedding/dashboard");
            }
            return View("Index");
        }

        [HttpPost("/register")]
        public IActionResult Register(User newUser)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "is taken");
                }
            }

            if (ModelState.IsValid == false)
            {
                return View("Index");
            }

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            newUser.Password = hasher.HashPassword(newUser, newUser.Password);

            db.Users.Add(newUser);
            db.SaveChanges();

            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("Dashboard", "Wedding");
        }

        [HttpPost("/login")]
        public IActionResult Login(LoginUser user)
        {
            if (ModelState.IsValid == false)
            {
                return View("Index");
            }

            User dbUser = db.Users.FirstOrDefault(u => u.Email == user.LoginEmail);

            if (dbUser == null)
            {
                ModelState.AddModelError("Email", "Email not found.");
            }

            // If any error was added manually above.
            if (ModelState.IsValid == false)
            {
                return View("Index");
            }

            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            PasswordVerificationResult pwCompareResult = hasher.VerifyHashedPassword(user, dbUser.Password, user.LoginPassword);

            if (pwCompareResult == 0)
            {
                ModelState.AddModelError("LoginEmail", "Incorrect password.");
                return View("Index");
            }

            HttpContext.Session.SetInt32("UserId", dbUser.UserId);
            return RedirectToAction("Dashboard", "Wedding");
        }

        [HttpGet("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
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
