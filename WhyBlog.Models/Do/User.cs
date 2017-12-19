﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhyBlog.Models.Do
{
    [Table("TBU_User")]
   public class User:BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string UserName { get; set; }

        
        public string Account { get; set; }

        public string Pwd { get; set; }

        public string Email { get; set; }
    }
}
