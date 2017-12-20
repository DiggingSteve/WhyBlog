﻿using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WhyBlog.Models.Do.Interface;

namespace WhyBlog.Models.Do
{
    
   public abstract  class BaseEntity:ISoftDeleted
    {
        
       [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]  //设置自增
        public int Id { get; set; }

        
        public bool IsDeleted { get; set; }
    }
}