using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BLOG.Models
{
    public class Application_Db : DbContext
    {
        public Application_Db()
            : base("DefaultConnection")
        {

        }
        public DbSet<Blogger> administrador { get; set; }
    }
}