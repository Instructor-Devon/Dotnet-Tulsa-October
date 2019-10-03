using Microsoft.AspNetCore.Mvc;
namespace WebThing.Controllers
{
    public class HomeController : Controller
    {
        // localhost:5000/
        [Route("")]
        public ViewResult Index()
        {
            return View();
        }
        // localhost:5000/:turtle
        [Route("{turtle}")]
        public ViewResult Ninja(string turtle)
        {
            ViewBag.Ninja = turtle;

            return View();
        }
    }
}