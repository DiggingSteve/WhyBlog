using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WhyBlog.EF.Entity
{
    
   public abstract class BaseEntity
    {
        
       [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //设置自增
        public int Id { get; set; }

        public int IsDel { get; set; }
    }
}
