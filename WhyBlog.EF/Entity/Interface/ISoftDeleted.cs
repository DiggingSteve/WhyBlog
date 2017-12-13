using System;
using System.Collections.Generic;
using System.Text;

namespace WhyBlog.EF.Entity.Interface
{
   public interface ISoftDeleted
    {
        bool IsDeleted { get; set; }
    }
}
