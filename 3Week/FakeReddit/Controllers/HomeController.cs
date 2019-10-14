using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoggedIn.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace LoggedIn.Controllers
{
    public class HomeController : Controller
    {
        private DashboardContext dbContext;
        public HomeController(DashboardContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {

            return View();
        }

        // Create
        [HttpPost("create")]
        public IActionResult Create(LogRegModel model)
        {
            DashboardUser user = model.Register;
            if(ModelState.IsValid)
            {
                // QUERY FOR UNIQUE EMAIL
                if(dbContext.Users.Any(u => u.Email == user.Email))
                {
                    // we have a problem
                    ModelState.AddModelError("Register.Email", "Email already in use!");
                    return View("Index");
                }

                // if all checks out, put them in the db!
                PasswordHasher<DashboardUser> hasher = new PasswordHasher<DashboardUser>();
                string hashedPw = hasher.HashPassword(user, user.Password);
                user.Password = hashedPw;

                dbContext.Users.Add(user);
                dbContext.SaveChanges();

                return RedirectToAction("Index", "Dashboard");
            }
            
            return View("Index");
        }
        [HttpPost("login")]
        public IActionResult Login(LogRegModel model)
        {
            LoginUser user = model.Login;
            if(ModelState.IsValid)
            {
                // is this user's email in the db???
                DashboardUser userCheck = dbContext.Users.FirstOrDefault(u => u.Email == user.EmailAttempt);
                if(userCheck == null)
                {
                    // we have a problem
                    ModelState.AddModelError("Login.EmailAttempt", "Invalid Email/Password");
                    return View("Index");
                }
                else
                {
                    // check for db.password == form.password
                    PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                    PasswordVerificationResult result = hasher.VerifyHashedPassword(user, userCheck.Password, user.PasswordAttempt);
                    if(result == 0)
                    {
                        // we have a problem
                        ModelState.AddModelError("Login.EmailAttempt", "Invalid Email/Password");
                        return View("Index");
                    }
                    else
                    {
                        // we made it!
                        HttpContext.Session.SetInt32("userId", userCheck.UserId);
                        return RedirectToAction("Index", "Dashboard");
                    }
                }
            }
            return View("Index");
        }
        [HttpGet("logout")]
        public RedirectToActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
