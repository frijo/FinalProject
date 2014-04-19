using BLOG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace BLOG.Controllers
{
    public class AcountController : Controller
    {
        //
        // GET: /Login/
        private Application_Db db = new Application_Db();

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(String NickName="",String Password="",String Name="", String SN1="",String SN2="",String Ocupation="")
        {
            //String passwordEncrip = Helper.EncodePassword(string.Concat(usuario.NombreLogin, usuario.Password));
            Blogger nuevo = new Blogger();
            nuevo.NickName = NickName;
            nuevo.password = Password;
            nuevo.Name = Name;
            nuevo.Ocupacion = Ocupation;
            nuevo.SocialNet1 = SN1;
            nuevo.SocialNet2 = SN2;

            if (ModelState.IsValid)
            {
                db.Bloggers.Add(nuevo);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
