using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WhyBlog.Models;
using WhyBlog.EF;

namespace WhyBlog.Controllers
{

    public class HomeController : Controller
    {
        private readonly BlogContext db;
        public HomeController(BlogContext dbcontext)
        {
            this.db = dbcontext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = db.Users.Where(p => p.IsDel == -1).FirstOrDefault().Account;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            db.Users.Add(new EF.Entity.User() { UserName = "admin", Account = "admin", Pwd = "123456", IsDel = -1 });
            db.SaveChanges();
            return View();
        }

 

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
