using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WhyBlog.Infrastructure;
using WhyBlog.Models.Dto;
using WhyBlog.Models.Vo;
using WhyBlog.Models.Enum;
using WhyBlog.Infrastructure.Core;

namespace WhyBlog.WebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    public class GitApiController : BaseController
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        
        public async Task<GitUser> SigninByGit(GitSignInPara data)
        {
            if (User.Identity.IsAuthenticated)
            {
                string accountSource = CookieUtil.GetCookie(AccountSource.LoginSource, User);
                if (accountSource == AccountSource.Git)
                {
                    //直接返回cookie中的结果，并建立session
                }
                
            }
            else
            {
                //没有授权 先获取授权，插入自己的库，再加cookie
            }
          
            var identity = new ClaimsIdentity("Forms");
            
            identity.AddClaim(new Claim(ClaimTypes.Name, Convert.ToString(user.Name)));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            identity.AddClaim(new Claim(AccountSource.LoginSource, AccountSource.Git ));
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync("login", principal, new AuthenticationProperties { IsPersistent = true ,ExpiresUtc=DateTimeOffset.UtcNow.AddHours(1)});//
            return user;
        }


    }
}
