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
        protected Context Context { get; set; }
    

 
        public DominService(ClaimsPrincipal User,HttpContext context)
        {
            Context = new Context(User, context);
            
        }
    }
}
