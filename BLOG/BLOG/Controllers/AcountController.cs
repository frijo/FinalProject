using BLOG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Security.Cryptography;
using System.Web.Security;

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
             
            var passCryp = new SimpleCrypto.PBKDF2();
            var crypPass = passCryp.Compute(Password);


            Blogger nuevo = new Blogger();
            nuevo.NickName = NickName;
            nuevo.password = crypPass;
            nuevo.passwordSalt = passCryp.Salt;
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
        [HttpPost]


        public ActionResult Login(String LoginUser = "", String LoginPass = "")
        {
            if (ModelState.IsValid)
            {
                if (IsValid(LoginUser, LoginPass))
                {
                    FormsAuthentication.SetAuthCookie(LoginUser, false);
                    return RedirectToAction("Index", "Admin");

                }
                else 
                {
                    ModelState.AddModelError(""," Login Data Incorrect");
                }
            }
            return View();
        }


        private bool IsValid(String NickName, String Password)
        {
            bool Valid = false;
            var passCryp = new SimpleCrypto.PBKDF2();

            using (var data = new Application_Db())
            {
                var user = data.Bloggers.FirstOrDefault(n => n.NickName == NickName);
                if (user != null)
                {
                    if (user.password == passCryp.Compute(Password, user.passwordSalt))
                    {
                        Valid = true;
                    }
                }
            }
            return Valid;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
