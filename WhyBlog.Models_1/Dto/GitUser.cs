﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WhyBlog.Models.Dto
{
   public class GitUser
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Login { get; set; }
        public string Avatar_url { get; set; }
    }
}
