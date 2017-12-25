using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WhyBlog.Models;
using WhyBlog.EF;
using WhyBlog.EF.Dao;
using WhyBlog.Infrastructure.Core;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace WhyBlog.Controllers
{

    public class HomeController : BaseController
    {
      
        private readonly IUserDao service;
        public HomeController( IUserDao service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.service = service;
        }
        
        public IActionResult Index()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {

            }
            
            return View();
        }

     
 

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
