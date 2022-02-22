using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Login_and_Registration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Login_and_Registration.Controllers
{
    public class HomeController : Controller
    {
        private Login_and_RegistrationContext db;
        public HomeController(Login_and_RegistrationContext context)
        {
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost("/register")]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Account with that email already exists.");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);

                user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;

                db.Users.Add(user);
                db.SaveChanges();


                LoginUser autoLogin = new LoginUser();
                autoLogin.Email = user.Email;
                autoLogin.Password = user.Password;
                // return RedirectToAction("LoginSubmit", autoLogin);
                return AutoLoginSubmit(autoLogin);
            }
            return View("Index");
        }

        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost("/loginsubmit")]
        public IActionResult LoginSubmit(LoginUser userSubmission)
        {
            var userInDb = db.Users.FirstOrDefault(u => u.Email == userSubmission.Email);

            if (userInDb == null)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                Console.WriteLine("userInDB == null");
                return View("Login");
            }

            var hasher = new PasswordHasher<LoginUser>();

            var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);

            if (result == 0)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                Console.WriteLine("result == null");
                return View("Login");
            }
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            return RedirectToAction("Success");
        }

        [HttpPost("/autologinsubmit")]
        public IActionResult AutoLoginSubmit(LoginUser userSubmission)
        {
            var userInDb = db.Users.FirstOrDefault(u => u.Email == userSubmission.Email);

            if (userInDb == null)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                Console.WriteLine("userInDB == null");
                return View("Login");
            }

            // var hasher = new PasswordHasher<LoginUser>();
            // var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);

            if (userSubmission.Password != userInDb.Password)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                Console.WriteLine("result == null");
                return View("Login");
            }
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            return RedirectToAction("Success");
        }

        [HttpGet("/Success")]
        public IActionResult Success()
        {
            var userInDb = db.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
            if (userInDb == null)
            {
                return RedirectToAction("Index");
            }
            return View("Success");
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
