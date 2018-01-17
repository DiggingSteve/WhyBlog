using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WhyBlog.Models.Do
{
    [Table("TB_Blog")]
  public  class Blog :BaseEntity
    {
        /// <summary>
        /// user id foreign key
        /// </summary>
        public int Uid { get; set; }
        [Column(TypeName = "text")]
        public string Html { get; set; }

        [Column(TypeName ="varchar(100)")]
        public string Title { get; set; }
    }
}
