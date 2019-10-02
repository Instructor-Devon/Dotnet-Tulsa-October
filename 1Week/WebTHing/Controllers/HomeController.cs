using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebTHing.Models;

namespace WebTHing.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public ViewResult Index()
        {
            return View();
        }

        [Route("login")]
        public IActionResult Login()
        {
            bool isValid = true;
            if(isValid)
            {
                // return redirect
                return Redirect("");
            }
            else
            {
                // return view
                return View();
            }
        }

        
    }
}
