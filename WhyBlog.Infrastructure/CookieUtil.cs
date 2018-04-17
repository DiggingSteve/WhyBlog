using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace WhyBlog.Infrastructure
{
    public class CookieUtil
    {
        public static string GetCookie(string key, ClaimsPrincipal principal)
        {
            //return (from c in principal.Claims
            //               where c.Type == key
            //               select c.Value).FirstOrDefault();

            return principal.Claims.Where(o => o.Type == key).Select(o => o.Value).FirstOrDefault();
        }
    }
}
