using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BLOG.Models
{
    public class Blogger
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public String NickName { get; set; }
        [Required]
        public String password { get; set; }
        [Required]
        public String passwordSalt { get; set; }
        [Required]
        public String Name { get; set; }
        
        public String Ocupacion { get; set; }
        public String SocialNet1 { get; set; }
        public String SocialNet2 { get; set; }
        //public byte[] Image { get; set; }

    }
}