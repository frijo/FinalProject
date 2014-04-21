using BLOG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Security.Cryptography;
using System.Web.Security;
using System.IO;


namespace BLOG.Controllers
{
    public class AcountController : Controller
    {
        //
        // GET: /Login/
        private Application_Db db = new Application_Db();



        public ActionResult Information()
        {
            List<Blogger> blogger = db.Bloggers.ToList();
            ViewBag.Bloggers = blogger;
           
            return View();

        }
        public ActionResult IndexUser()
        {
            List<Blogger> blogger = db.Bloggers.ToList();
            ViewBag.Bloggers = blogger;

            return View();

        }
        [HttpPost]
        public ActionResult Information(int id, int img)
        {

            ViewBag.Pic = img;

            Blogger insp = db.Bloggers.Find(id);

            return View(insp);

        }



        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(String NickName = "", String Password = "", String Name = "", String SN1 = "", String SN2 = "", String Ocupation = "" )
        {

            // HttpPostedFileBase image,  ---> Parametro
            Blogger nuevo = new Blogger();
 

            var passCryp = new SimpleCrypto.PBKDF2();
            var crypPass = passCryp.Compute(Password);


            //string filename = "";

            //byte[] bytes;

            //int BytestoRead;

            //int numBytesRead;


            //if (image != null)
            //{

            //    filename = Path.GetFileName(image.FileName);

            //    bytes = new byte[image.ContentLength];

            //    BytestoRead = (int)image.ContentLength;

            //    numBytesRead = 0;

            //    while (BytestoRead > 0)
            //    {

            //        int n = image.InputStream.Read(bytes, numBytesRead, BytestoRead);

            //        if (n == 0) break;

            //        numBytesRead += n;

            //        BytestoRead -= n;

            //    }

            //    nuevo.Image = bytes;

            //}

                       
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
        public ActionResult Edit(int id = 0)
        {
             Blogger blog = db.Bloggers.Find(id);
             if (blog == null)
            {
                return HttpNotFound();
            }
             ViewBag.blogger = blog;
            
            return View();

            
        }
        [HttpPost]
        public ActionResult Edit(int id = 0, String NickName = "", String Password = "", String Name = "", String SN1 = "", String SN2 = "", String Ocupation = "")
        {

            if (NickName != "" && Password != "" && Name != "")
            {
                var passCryp = new SimpleCrypto.PBKDF2();
                var crypPass = passCryp.Compute(Password);

                if (ModelState.IsValid)
                {
                    Blogger blog = db.Bloggers.Find(id);


                    blog.NickName = NickName;
                    blog.Name = Name;
                    blog.password = crypPass;
                    blog.passwordSalt = passCryp.Salt;
                    blog.Ocupacion = Ocupation;
                    blog.SocialNet1 = SN1;
                    blog.SocialNet2 = SN2;

                    db.Entry(blog).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Information");
                }
            }
            else
            {
                ModelState.AddModelError("Acount", " Error, incorrect fields");
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
                    return RedirectToAction("Index", "Blog");

                }
                else 
                {
                    ModelState.AddModelError(""," Login Data Incorrect");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("IndexUser","Blog");
        }

        private ActionResult RedirectToAction()
        {
            throw new NotImplementedException();
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
