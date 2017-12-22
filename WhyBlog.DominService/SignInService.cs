using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using WhyBlog.Infrastructure.Core;
using WhyBlog.Models.Vo;
using WhyBlog.Models.Dto;
using WhyBlog.Infrastructure;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using WhyBlog.Models.Enum;
using WhyBlog.EF.Dao;
using WhyBlog.Models.Do;
using AutoMapper;

namespace WhyBlog.DominService
{
    public class SignInService : DominService, ISignInService
    {
        protected IUserDao _userDao;
        
        public SignInService(ClaimsPrincipal User, HttpContext contex, IUserDao userDao,IMapper mapper) : base(User, contex,mapper)
        {
            _userDao = userDao;
        }

        public UserView GetGitUser()
        {

            return new UserView { };
        }

        private async Task InserCookie(GitUser user)
        {
            var identity = new ClaimsIdentity("Forms");

            identity.AddClaim(new Claim(ClaimTypes.Name, Convert.ToString(user.Name)));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            identity.AddClaim(new Claim(AccountSource.LoginSource, AccountSource.Git));
            var principal = new ClaimsPrincipal(identity);
            await Context.HttpContext.SignInAsync("login", principal, new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1) });//
        }

        public async Task<UserView> OauthFromGit(GitSignInPara data)
        {
            Dictionary<string, string> postData = new Dictionary<string, string>();
            postData.Add("code", data.Code);
            postData.Add("client_secret", data.Client_secret);
            postData.Add("client_id", data.Client_id);
            string token = await HttpUtil.HttpPostAsync("https://github.com/login/oauth/access_token", postData, Encoding.UTF8);
            string pattern = @"(?<=access_token=)\w*";
            token = Regex.Match(token, pattern).Value;
            string userStr = await HttpUtil.HttpGetAsync("https://api.github.com/user?access_token=" + token, Encoding.UTF8);
            GitUser gitUser = JsonConvert.DeserializeObject<GitUser>(userStr);
            //插入Cookie
            await InserCookie(gitUser);
            CreateUser(gitUser);
            return new UserView();
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private bool CreateUser(GitUser gitUser)
        {
            User user =  _mapper.Map<User>(gitUser);
           return _userDao.Add(user);
        }

    }
}
