using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using LoggedIn.Filters;
using LoggedIn.Models;

namespace LoggedIn.Controllers
{
    [Route("Dashboard")]
    [LoggedIn]
    public class DashboardController : Controller
    {
        private DashboardUser loggedInUser
        {
            get { return dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("userId")); }
        } 
        private DashboardContext dbContext;
        public DashboardController(DashboardContext context)
        {
            dbContext = context;
        }
        // localhost:5000/Dashboards
        [HttpGet("")]
        public IActionResult Index()
        {
            // INCLUDE == JOIN;
            var viewModel = dbContext.Posts
                .Include(p => p.Author).ToList();

            ViewBag.UserId = loggedInUser.UserId;
            ViewBag.Users = dbContext.Users.ToList();

            return View(viewModel);
        }
        [HttpPost("create")]
        public IActionResult Create(Post post)
        {
            if(ModelState.IsValid)
            {
                dbContext.Posts.Add(post);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
             // INCLUDE == JOIN;
            var viewModel = dbContext.Posts
                .Include(p => p.Author).ToList();
            ViewBag.UserId = loggedInUser.UserId;
            ViewBag.Users = dbContext.Users.ToList();
            return View("Index", viewModel);
        }
        [HttpGet("vote/{postId}/{isUpvote}")]
        public IActionResult Vote(int postId, bool isUpvote)
        {
            if(loggedInUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            // check if user has already voted on this post...
            Post thePost = dbContext.Posts.FirstOrDefault(p => p.PostId == postId);
            if(!thePost.VotesReceived.Any(v => v.UserId == loggedInUser.UserId))
            {
                // already posted!!
                Vote newVote = new Vote()
                {
                    PostId = postId,
                    IsUpvote = isUpvote,
                    UserId = loggedInUser.UserId
                };
                dbContext.Add(newVote);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");

        }
    }
}