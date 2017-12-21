using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhyBlog.Models.Do
{
    [Table("TBU_User")]
    public class User : BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string UserName { get; set; }


        public string Account { get; set; }

        public string Pwd { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// 第三方来源id
        /// </summary>
        public int Sid { get; set; }

        /// <summary>
        /// git头像地址
        /// </summary>
        public string Avatar_url{get;set;}

        /// <summary>
        /// 用户来源
        /// </summary>
        public string UserSource { get; set; }
    }
}
