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
using WhyBlog.Models.Po;
using AutoMapper;
using System.Linq;
using WhyBlog.EF;

namespace WhyBlog.DominService
{
    public class SignInService : DominService, ISignInService
    {
     
        private readonly BlogContext _db;

        public SignInService(BlogContext db, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor)
        {
            this._db = db;
        }

        public UserView GetGitUser()
        {
            ClaimsPrincipal User = _context.HttpContext.User;
            var userSid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid);
            int.TryParse(userSid?.Value, out int sid);
            var user = _db.Users.Where(p => p.Sid == sid && p.UserSource == AccountSource.Git).FirstOrDefault();
            UserView gitUser = _mapper.Map<UserView>(user);
            return gitUser;
        }

        /// <summary>
        /// cookie只存git 的id以及该用户来源
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task InserCookie(GitUser user,int userId)
        {
            var identity = new ClaimsIdentity("Forms");
            identity.AddClaim(new Claim(ClaimTypes.Sid, user.Id.ToString()));
            identity.AddClaim(new Claim("Id",userId.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            identity.AddClaim(new Claim(AccountSource.LoginSource, AccountSource.Git));
            var principal = new ClaimsPrincipal(identity);
            await _context.HttpContext.SignInAsync("login", principal, new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTimeOffset.MaxValue });//
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
            if (gitUser.Login == null)
                return new UserView { NickName="Token过期" };
           int userId= CreateUser(gitUser);
            //插入Cookie
            await InserCookie(gitUser,userId);
            
            UserView userView = _mapper.Map<UserView>(gitUser);
            return userView;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns>user Id</returns>
        private int CreateUser(GitUser gitUser)
        {
            
            User user = _mapper.Map<User>(gitUser);
            var existedUser = _db.Users.Where(p => p.Sid == gitUser.Id && p.UserSource == AccountSource.Git).FirstOrDefault();
            if (existedUser != null)
            {
                return existedUser.Id;
            }

            else
            {
                _db.Users.Add(user);
                return _db.SaveChanges();
            }
      
        }

        public async Task SignOut()
        {
            
            await _context.HttpContext.SignOutAsync("login");
           
        }
    }
}
