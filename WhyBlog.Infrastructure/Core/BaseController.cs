using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace WhyBlog.Infrastructure.Core
{
    public class BaseController:Controller
    {
        protected CoreSession CoreSession;
        public BaseController()
        {
            CoreSession = new CoreSession(User,HttpContext);
        }
    }
}
