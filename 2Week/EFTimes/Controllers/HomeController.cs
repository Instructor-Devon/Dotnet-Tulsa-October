using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DBTimes.Models;
using Microsoft.Extensions.Configuration;

namespace DBTimes.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(MyContext context)
        {
            // SERVICE COMES OUT
            dbContext = context;
        }
        private MyContext dbContext;
        [HttpGet("")]
        public IActionResult Index()
        {
            // var ninjas = DbConnector.Query("SELECT * FROM ninjas");


            // SELECT * FROM Ninjas;
            var allNinjas = dbContext.Ninjas;

            ViewBag.Ninjas = allNinjas;
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
            // string q = $"SELECT * FROM ninjas WHERE NinjaId = {ninjaId}";
            var oneNinja = dbContext.Ninjas.FirstOrDefault(ni => ni.NinjaId == ninjaId);
           
            return View(oneNinja);
        }
        [HttpPost("ninja/{ninjaId}/update")]
        public IActionResult Update(Ninja ninja, int ninjaId)
        {
            if(ModelState.IsValid)
            {
                // query for a ninja to update
                var toUpdate = dbContext.Ninjas.FirstOrDefault(ni => ni.NinjaId == ninjaId);
                toUpdate.Name = ninja.Name;
                toUpdate.Bio = ninja.Bio;
                toUpdate.Color = ninja.Color;

                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Ninja");
        }
        [HttpGet("ninja/{ninjaId}/delete")]
        public IActionResult Delete(int ninjaId)
        {
            // query for a ninja to delete
            var toDelete = dbContext.Ninjas.FirstOrDefault(ni => ni.NinjaId == ninjaId);
            dbContext.Ninjas.Remove(toDelete);
            dbContext.SaveChanges();

            string q = $"DELETE FROM ninjas WHERE NinjaId = {ninjaId}";
            // DbConnector.Execute(q);
            return RedirectToAction("Index");
        }
        [HttpPost("create")]
        public IActionResult Create(Ninja ninja)
        {
            if(ModelState.IsValid)
            {
                dbContext.Ninjas.Add(ninja);
                dbContext.SaveChanges();
                
                // create a ninja in the db!
                string q = $@"
                    INSERT INTO ninjas (Name, Color, Email, SecretCode, Bio) 
                    VALUES ('{ninja.Name}', '{ninja.Color}', '{ninja.Email}', '{ninja.SecretCode}', '{ninja.Bio}')
                ";
                // DbConnector.Execute(q);
                return RedirectToAction("Index");
            }
            return View("New");
        }
    }
}
