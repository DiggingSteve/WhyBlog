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
using WhyBlog.Models.Enum;
using WhyBlog.Infrastructure.Core;
using WhyBlog.DominService;
using WhyBlog.Models.Vo;
using Microsoft.AspNetCore.Http;

namespace WhyBlog.WebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    public class GitApiController : BaseController
    {
        ISignInService SignInService;
        
        public GitApiController(ISignInService signInService, IHttpContextAccessor httpContextAccessor) :base(httpContextAccessor)
        {
            SignInService = signInService;
            
            
        }
        /// <summary>
        /// 登录返回用户视图
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        
        public async Task<UserView> SigninByGit(GitSignInPara data)
        {
            UserView user = new UserView();
            if (User.Identity.IsAuthenticated)
            {
                string accountSource = CookieUtil.GetCookie(AccountSource.LoginSource, User);
                if (accountSource == AccountSource.Git)
                {
                    //直接返回cookie中的结果，并建立session
                    user= SignInService.GetGitUser();
                }
            }
            else
            {
                //没有授权 先获取授权，插入自己的库，再加cookie
                user= await SignInService.OauthFromGit(data);
            }
       
            return user;
        }


        /// <summary>
        /// 退出登录
        /// </summary>
        
        /// <returns></returns>
        [HttpPost]

        public async Task<bool> SignOut()
        {
          await  SignInService.SignOut();
            return true ;

        }
           
    }
}
