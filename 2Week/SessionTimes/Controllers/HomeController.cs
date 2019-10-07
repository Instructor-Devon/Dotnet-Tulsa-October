using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionTimes.Models;

namespace SessionTimes.Controllers
{
    public class HomeController : Controller
    {
        private static string countKey = "count";
        public int? SessionCount
        {
            get { return HttpContext.Session.GetInt32(countKey); }
            set { HttpContext.Session.SetInt32("count", (int)value); }
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            // First Time User Experience
            // int? x = 3;
            // int y = 0;
            // y = (int)x;

            if(HttpContext.Session.GetObjectFromJson<List<Ninja>>("ninjas") == null)
            {
                HttpContext.Session.SetObjectAsJson("ninjas", new List<Ninja>());
            }

            // check to see if session value exists
            var sessionCount = HttpContext.Session.GetInt32(countKey);
            if(sessionCount == null)
            {
                // if not session["count"]
                // if it doesn't set it to logical default value
                HttpContext.Session.SetInt32("count", 0);
            }
            ViewBag.Count = HttpContext.Session.GetInt32("count");
            ViewBag.Ninjas = HttpContext.Session.GetObjectFromJson<List<Ninja>>("ninjas");
            // session["count"] = 0
            return View();
        }
        [HttpGet("new")]
        public IActionResult New()
        {

            return View();
        }
        [HttpGet("click")]
        public IActionResult Click()
        {
            SessionCount++;

            var sessionCount = HttpContext.Session.GetInt32("count");
            sessionCount++;
            HttpContext.Session.SetInt32("count", (int)sessionCount);            
            return RedirectToAction("Index");
        }
        [HttpPost("create")]
        public IActionResult Create(Ninja ninja)
        {
            if(ModelState.IsValid)
            {
                // enter data into db
                var ninjas = HttpContext.Session.GetObjectFromJson<List<Ninja>>("ninjas");
                ninjas.Add(ninja);
                HttpContext.Session.SetObjectAsJson("ninjas", ninjas);
                // charge a credit card number
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
