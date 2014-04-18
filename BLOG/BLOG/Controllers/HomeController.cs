using BLOG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLOG.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private Application_Db db = new Application_Db();
        public ActionResult Index()
        {
            Blogger nuevo = new Blogger();
            nuevo.NickName = "NickName";
            nuevo.password = "Password";
            nuevo.SocialNet1 = "SN1";
            nuevo.SocialNet2 = "SN2";

            if (ModelState.IsValid)
            {
                db.Bloggers.Add(nuevo);
                db.SaveChanges();
            }
            return View();
            
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
