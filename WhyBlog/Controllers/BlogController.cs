using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WhyBlog.Infrastructure.Core;
using Microsoft.AspNetCore.Http;
using WhyBlog.Models.Vo;
using WhyBlog.Infrastructure;
using WhyBlog.Models.Enum;
using WhyBlog.DominService;

namespace WhyBlog.Controllers
{
    public class BlogController : BaseController
    {
        private ISignInService _signService;
        
        public BlogController(IHttpContextAccessor httpContextAccessor, ISignInService siginService) : base(httpContextAccessor)
        {
            this._signService = siginService;
        }


        public IActionResult Index(int id)
        {
            BlogView model = new BlogView(Context.HttpContext);
            model.Blog.Id = id;
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
            else model.IsLogin = false;
            return View(model);
        }
    }
}