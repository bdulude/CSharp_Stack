using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Wedding_Planner.Models;

namespace Wedding_Planner.Controllers
{
    public class WeddingController : Controller
    {
        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }
        private bool loggedIn
        {
            get
            {
                return uid != null;
            }
        }
        private Wedding_PlannerContext db;
        public WeddingController(Wedding_PlannerContext context)
        {
            db = context;
        }

        [HttpGet("/wedding/dashboard")]
        public IActionResult Dashboard()
        {
            if (!loggedIn)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Wedding> weddings = db.Weddings
            .Include(w => w.RSVPs)
            .ToList();

            return View("Dashboard", weddings);
        }

        [HttpGet("/wedding/{weddingId}")]
        public IActionResult ShowWedding(int weddingId)
        {
            if (!loggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            Wedding wedding = db.Weddings
                .Include(w => w.RSVPs)
                .ThenInclude(r => r.User)
                .SingleOrDefault(w => w.WeddingId == weddingId);
            return View("Show", wedding);
        }

        [HttpGet("/wedding/new")]
        public IActionResult NewWedding()
        {
            if (!loggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("New");
        }

        [HttpPost("/wedding/create")]
        public IActionResult CreateWedding(Wedding wedding)
        {
            if (!loggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            if (wedding.WeddingDate < DateTime.Now)
            {
                ModelState.AddModelError("WeddingDate", "Date needs to be in the future.");
            }
            if (!ModelState.IsValid)
            {
                return View("New");
            }

            wedding.CreatorId = (int)uid;
            db.Weddings.Add(wedding);
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("/wedding/delete/{weddingId}")]
        public IActionResult DeleteWedding(int weddingId)
        {
            if (!loggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            Wedding wedding = db.Weddings.SingleOrDefault(w => w.WeddingId == weddingId);
            if (wedding != null)
            {
                db.Weddings.Remove(wedding);
                db.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }

        [HttpGet("/RSVP/{weddingId}")]
        public IActionResult CreateRSVP(int weddingId)
        {
            if (!loggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            RSVP rsvp = new RSVP();
            rsvp.UserId = (int)uid;
            rsvp.WeddingId = weddingId;
            db.RSVPs.Add(rsvp);
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("/unRSVP/{weddingId}")]
        public IActionResult DeleteRSVP(int weddingId)
        {
            if (!loggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            RSVP rsvp = db.RSVPs.FirstOrDefault(r => r.WeddingId == weddingId && r.UserId == (int)uid);
            if (rsvp != null)
            {
                db.RSVPs.Remove(rsvp);
                db.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }
    }
}