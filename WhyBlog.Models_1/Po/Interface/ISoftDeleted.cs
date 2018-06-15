using System;
using System.Collections.Generic;
using System.Text;

namespace WhyBlog.Models.Po.Interface
{
   public interface ISoftDeleted
    {
        bool IsDeleted { get; set; }
         DateTime DeleteTime { get; set; }
    }
}
