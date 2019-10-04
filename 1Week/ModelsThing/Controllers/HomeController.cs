using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebThing.Models;

namespace WebThing.Controllers
{
    public class HomeController : Controller
    {
        // localhost:5000/
        [Route("")]
        public ViewResult Index()
        {
            var turtlesList = NinjaTurtle.MainTurtles.ToList();
            return View(turtlesList);
        }
        [Route("new")]
        public ViewResult NewTurtle()
        {
            return View();
        }
        // localhost:5000/:turtle
        [Route("{turtle}")]
        public ViewResult Ninja(string turtle)
        {
            var turtles = NinjaTurtle.MainTurtles;
            NinjaTurtle theTurtle = turtles.FirstOrDefault(t => t.Name.ToLower() == turtle.ToLower());

            return View(theTurtle);
        }
        [HttpPost("create")]
        public IActionResult Create(NinjaTurtle model)
        {
            // take the data and enter in the db
            // before we do this... VALIDATE
            return View("Ninja", model);
        }
    }
}