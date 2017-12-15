using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhyBlog.Models.Dto
{
    public class GitSignInPara
    {
        public string Code { get; set; }

        public string Client_id { get; set; }

        public string Client_secret { get; set; }
    }
}
