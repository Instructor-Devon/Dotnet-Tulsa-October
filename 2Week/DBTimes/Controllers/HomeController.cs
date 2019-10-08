using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DBTimes.Models;

namespace DBTimes.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            var ninjas = DbConnector.Query("SELECT * FROM ninjas");
            ViewBag.Ninjas = ninjas;
            return View();
        }
        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }
        [HttpGet("ninja/{ninjaId}")]
        public IActionResult Ninja(int ninjaId)
        {
            string q = $"SELECT * FROM ninjas WHERE NinjaId = {ninjaId}";
            var result = DbConnector.Query(q);
            if(result.Count < 1)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Ninja = result[0];
            return View();
        }
        [HttpGet("ninja/{ninjaId}/delete")]
        public IActionResult Delete(int ninjaId)
        {
            string q = $"DELETE FROM ninjas WHERE NinjaId = {ninjaId}";
            DbConnector.Execute(q);
            return RedirectToAction("Index");
        }
        [HttpPost("create")]
        public IActionResult Create(Ninja ninja)
        {
            if(ModelState.IsValid)
            {
                // create a ninja in the db!
                string q = $@"
                    INSERT INTO ninjas (Name, Color, Email, SecretCode, Bio) 
                    VALUES ('{ninja.Name}', '{ninja.Color}', '{ninja.Email}', '{ninja.SecretCode}', '{ninja.Bio}')
                ";
                DbConnector.Execute(q);
                return RedirectToAction("Index");
            }
            return View("New");
        }
    }
}
