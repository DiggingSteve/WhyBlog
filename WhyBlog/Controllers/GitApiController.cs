using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WhyBlog.Models.Dto;


namespace WhyBlog.Controllers
{
    [Route("api/[controller]/[Action]")]
    public class GitApiController : Controller
    {

        [HttpPost]
        public async Task<GitUser> GetToken(GitSignInPara data)
        {
            Dictionary<string, string> postData = new Dictionary<string, string>();
            postData.Add("code", data.Code);
            postData.Add("client_secret", data.Client_secret);
            postData.Add("client_id", data.Client_id);
            string token = await HttpUtil.HttpPostAsync("https://github.com/login/oauth/access_token", postData, Encoding.UTF8);
            string pattern = @"(?<=access_token=)\w*";
            token = Regex.Match(token, pattern).Value;
            string userStr = await HttpUtil.HttpGetAsync("https://api.github.com/user?access_token="+token, Encoding.UTF8);
            GitUser user = JsonConvert.DeserializeObject<GitUser>(userStr);
            
            return user;
        }




    }
}
