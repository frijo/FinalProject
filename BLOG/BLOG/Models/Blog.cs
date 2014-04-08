using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLOG.Models
{
    public class Blog 
    {
        public String BlogName { get; set; }
        public String Detail { get; set; }
       
        public String Title { get; set; }
        public DateTime date{ get; set; }
        public String Contain { get; set; }
    }
}
