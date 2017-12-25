using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace WhyBlog.Infrastructure.Core
{
    public class BaseController:Controller
    {
        protected Context Context;
        public BaseController(IHttpContextAccessor httpContextAccessor)
        {

            Context = new Context( httpContextAccessor.HttpContext);
        }

        
    }
}
