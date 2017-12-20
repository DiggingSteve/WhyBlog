using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using WhyBlog.Infrastructure.Core;

namespace WhyBlog.DominService
{
  public  class DominService
    {
        protected CoreSession Session { get; set; }

 
        public DominService(ClaimsPrincipal User,HttpContext context)
        {
            Session = new CoreSession(User, context);
        }
    }
}
