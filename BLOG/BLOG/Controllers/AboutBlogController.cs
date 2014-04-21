using BLOG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLOG.Controllers
{
    public class AboutBlogController : Controller
    {
        //
        // GET: /AboutBlog/

        private Application_Db db = new Application_Db();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(String NameBlog, String Detail)
        {
            InformationBlog nuevo = new InformationBlog();
            nuevo.Name = NameBlog;
            nuevo.Detail = Detail;

            if (ModelState.IsValid)
            {

                db.InformationBlogs.Add(nuevo);
                db.SaveChanges();


                //return RedirectToAction("Login");
            }

            return View();
        }



        public ActionResult Edit(int id=0)
        {
            return View();
        }
        public ActionResult Edit(int id=0 ,String Name="", String Detail="")
        {
            return View();
        }

    }
}
