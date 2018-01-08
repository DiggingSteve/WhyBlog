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
using WhyBlog.Models.Vo;
using WhyBlog.DominService;
using WhyBlog.Infrastructure;
using WhyBlog.Models.Enum;

namespace WhyBlog.Controllers
{

    public class HomeController : BaseController
    {


        private ISignInService _signService;
        
        public HomeController(  IHttpContextAccessor httpContextAccessor,ISignInService siginService) : base(httpContextAccessor)
        {
            this._signService = siginService;
        }
        
        public IActionResult Index()
        {
            IndexView model = new IndexView(Context.HttpContext);
            
            if (User.Identity.IsAuthenticated)
            {
                string accountSource = CookieUtil.GetCookie(AccountSource.LoginSource, User);
                if (accountSource == AccountSource.Git)
                {
                    //直接返回cookie中的结果，并建立session
                    model.User = _signService.GetGitUser();
                    model.IsLogin = true;

                }
            }
            return View(model);
        }

        public IActionResult Redirect()
        {
            BaseView model = new BaseView(Context.HttpContext);
            return View(model);
        }

     
 

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
