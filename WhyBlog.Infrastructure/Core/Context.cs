using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WhyBlog.Models.Enum;
using WhyBlog.Models.Dto;

namespace WhyBlog.Infrastructure.Core
{

    //dto 传递数据  vo 用户展示model do 数据库model
    public class Context
    {



        public ISession Session { get; set; }

        public HttpContext HttpContext { get; set; }

        public BlogUser BlogUser { get; set; }


        public Context( HttpContext httpContext)
        {
            ClaimsPrincipal User = httpContext.User;
            BlogUser = new BlogUser();
            HttpContext = httpContext;
            Session = httpContext.Session;
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "Id");
            if (string.IsNullOrEmpty(userIdClaim?.Value))
                return;
            if (int.TryParse(userIdClaim.Value, out int userId))
                BlogUser.Id = userId;


            // UsreName
            var userNameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            BlogUser.Name = userNameClaim?.Value;



            //var userRoleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            //GitUser. = userRoleClaim?.Value;
        }
    }
}
