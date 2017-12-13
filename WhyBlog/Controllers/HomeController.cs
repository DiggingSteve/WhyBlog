using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WhyBlog.Models;
using WhyBlog.EF;
using WhyBlog.EF.Service;
using WhyBlog.EF.Entity;

namespace WhyBlog.Controllers
{

    public class HomeController : Controller
    {
        private readonly BlogContext db;
        private readonly IUserService service;
        public HomeController(BlogContext dbcontext, IUserService service)
        {
            this.db = dbcontext;
            
            this.service = service;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = service.GetEntity(2).IsDeleted;
            service.Delete(2);
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            db.Users.Add(new EF.Entity.User() { UserName = "admin", Account = "admin", Pwd = "123456"});
            db.SaveChanges();
            return View();
        }

 

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
