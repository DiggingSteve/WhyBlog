using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace WhyBlog.Models.Vo
{
   public class UserView
    {


        public string NickName { get; set; }

        public string Email { get; set; }

        public string Avatar_url { get; set; }

        
    }
}
