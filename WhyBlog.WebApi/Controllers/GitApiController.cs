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


namespace WhyBlog.WebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    public class GitApiController : Controller
    {

        [HttpPost]
        public async Task<GitUser> SigninByGit(GitSignInPara data)
        {
            if (User.Identity.IsAuthenticated)
            {
                string accountSource = CookieUtil.GetCookie(AccountSource.LoginKey, User);
                if(accountSource==AccountSource.Git)

            }
            Dictionary<string, string> postData = new Dictionary<string, string>();
            postData.Add("code", data.Code);
            postData.Add("client_secret", data.Client_secret);
            postData.Add("client_id", data.Client_id);
            string token = await HttpUtil.HttpPostAsync("https://github.com/login/oauth/access_token", postData, Encoding.UTF8);
            string pattern = @"(?<=access_token=)\w*";
            token = Regex.Match(token, pattern).Value;
            string userStr = await HttpUtil.HttpGetAsync("https://api.github.com/user?access_token=" + token, Encoding.UTF8);
            GitUser user = JsonConvert.DeserializeObject<GitUser>(userStr);
            var identity = new ClaimsIdentity("Forms");
            identity.AddClaim(new Claim(ClaimTypes.Sid, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, Convert.ToString(user.Name)));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            identity.AddClaim(new Claim("AccountSource",AccountSource.git.ToString() ));
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync("login", principal, new AuthenticationProperties { IsPersistent = true ,ExpiresUtc=DateTimeOffset.UtcNow.AddHours(1)});//
            return user;
        }


    }
}
