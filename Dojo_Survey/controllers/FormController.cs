using Microsoft.AspNetCore.Mvc;
using System;

namespace Dojo_Survey.Controllers     //be sure to use your own project's namespace!
{
    public class FormController : Controller   //remember inheritance??
    {
        //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("")]     //associated route string (exclude the leading /)
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("submit")]
        public IActionResult FormSubmission(string name, string location, string lang, string comment)
        {
            var submission = new {
                Name = name,
                Location = location,
                Lang = lang,
                Comment = comment
            };
            // Console.WriteLine(submission.Name);
            return RedirectToAction("Result", submission);
        }

        [HttpGet]       //type of request
        [Route("result")]     //associated route string (exclude the leading /)
        public ViewResult Result(string name, string location, string lang, string comment)
        {
            // Console.WriteLine(name);
            ViewBag.Name = name;
            ViewBag.Location = location;
            ViewBag.Lang = lang;
            ViewBag.Comment = comment;
            return View("Result");
        }
    }
}