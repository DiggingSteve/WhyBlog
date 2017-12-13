using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WhyBlog.EF.Entity.Interface;

namespace WhyBlog.EF.Entity
{
    
   public abstract  class BaseEntity:ISoftDeleted
    {
        
       [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //设置自增
        public int Id { get; set; }

        
        public bool IsDeleted { get; set; }
    }
}
