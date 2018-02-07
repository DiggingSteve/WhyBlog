using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WhyBlog.Models.Po
{
    [Table("TB_Blog")]
  public  class Blog :BaseEntity
    {
        /// <summary>
        /// user id foreign key
        /// </summary>
    
        [Column(TypeName = "longtext")]
        public string Html { get; set; }

        [Column(TypeName = "longtext")]
        public string Summary { get; set; }

        [Column(TypeName ="varchar(100)")]
        public string Title { get; set; }

        [Column(TypeName ="text")]
        public string PicSummary { get; set; }
        public int Uid { get; set; }
        [ForeignKey("Uid")]
        public  User User { get; set; }
    }
}
