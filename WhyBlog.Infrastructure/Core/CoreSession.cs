using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WhyBlog.Models.Enum;

namespace WhyBlog.Infrastructure.Core
{
  public  class CoreSession
    {
        
        public string UserName { get; set; }

        public int UserId { get; set; }

        public string UserSource { get; set; }

        public string UserRole { get; set; }

        public ISession Session { get; set; }

        

        public CoreSession(ClaimsPrincipal User,HttpContext httpContext)
        {
            Session = httpContext.Session;
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid);
            if (string.IsNullOrEmpty(userIdClaim?.Value))
                return;
            if (int.TryParse(userIdClaim.Value, out int userId))
                UserId = userId;

            // UsreName
            var userNameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            UserName = userNameClaim?.Value;

            var userSourceClaim = User.Claims.FirstOrDefault(c=>c.Type==AccountSource.LoginSource);
            UserSource = userSourceClaim?.Value;

            var userRoleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            UserRole = userRoleClaim?.Value;
        }
    }
}
