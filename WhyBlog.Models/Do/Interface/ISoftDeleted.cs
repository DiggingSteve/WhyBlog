using System;
using System.Collections.Generic;
using System.Text;

namespace WhyBlog.Models.Do.Interface
{
   public interface ISoftDeleted
    {
        bool IsDeleted { get; set; }
    }
}
