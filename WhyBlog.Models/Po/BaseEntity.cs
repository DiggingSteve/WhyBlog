using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WhyBlog.Models.Po.Interface;

namespace WhyBlog.Models.Po
{
    
   public abstract  class BaseEntity:ISoftDeleted,ICreated
    {
        
       [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //设置自增
        public int Id { get; set; }

        
        public bool IsDeleted { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime ModifyTime { get; set; }

        public DateTime DeleteTime { get; set; }

        
    }
}
